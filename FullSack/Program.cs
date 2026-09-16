
using FullSack.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using SemiWare.Utils;

namespace FullSack
{
    public class Program
    {
        public static void Main(string[] args)
        {
			#region REGISTER SERVICES TO CONTAINER

			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<FullSackDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Cookbook"));
			});

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

			#endregion


			#region ADD MIDDLEWARES

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<FullSackDbContext>();
				Attempt.ToDo(
					action: context.Database.Migrate,
					interval: TimeSpan.FromSeconds(2),
					maxAttempts: 10,
					retryMessage: "Database is not ready to migrate yet. Retrying...");
			}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
				app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

			app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

			#endregion

			app.Run();
        }
    }
}
