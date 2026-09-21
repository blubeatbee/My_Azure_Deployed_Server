using FullSack.Entities;
using FullSack.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Globalization;

namespace FullSack.Data
{
	public static class SampleData
	{
		private static readonly CultureInfo cultureInfo = CultureInfo.InvariantCulture;

		public static async Task SeedRolesAndUsersAsync(this WebApplication app, IConfiguration config)
		{
			using var scope = app.Services.CreateScope();
			string[] seededRoles = [
				config.GetRoleName("0")!,
				config.GetRoleName("1")!,
				];
			await SeedIdentityRoles(scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>(), seededRoles);
			var section = config.GetSection("Users");
			KeyValuePair<User, string>[] seededUsers = [
				new(new User(){
					Email = section.GetSection("User0")["email"],
					UserName = section.GetSection("User0")["email"],
					Surname = section.GetSection("User0")["name"],
					FirstName = section.GetSection("User0")["name"],
					NormalizedEmail = section.GetSection("User0")["email"]!.ToUpper(cultureInfo),
					NormalizedUserName = section.GetSection("User0")["email"]!.ToUpper(cultureInfo),
					NormalizedSurname = section.GetSection("User0")["name"]!.ToUpper(cultureInfo),
					NormalizedFirstName = section.GetSection("User0")["name"]!.ToUpper(cultureInfo),
					},
					section.GetSection("User0")["password"]!),
				new(new User() {
					Email = section.GetSection("User1")["email"],
					UserName = section.GetSection("User1")["email"],
					Surname = section.GetSection("User1")["name"],
					FirstName = section.GetSection("User1")["name"],
					NormalizedEmail = section.GetSection("User1")["email"]!.ToUpper(cultureInfo),
					NormalizedUserName = section.GetSection("User1")["email"]!.ToUpper(cultureInfo),
					NormalizedSurname = section.GetSection("User1")["name"]!.ToUpper(cultureInfo),
					NormalizedFirstName = section.GetSection("User1")["name"]!.ToUpper(cultureInfo),
					},
					section.GetSection("User1")["password"]!)
				];
			var userManager = await SeedIdentityUsers(scope.ServiceProvider.GetRequiredService<UserManager<User>>(), seededUsers);
			await AssignUserToRole(userManager, [
				new(seededUsers[0].Key, seededRoles[0]),
				new(seededUsers[1].Key, seededRoles[1]),
			]);
		}

		public static async Task SeedIdentityRoles(RoleManager<IdentityRole> roleManager, params string[] roleNames)
		{
			for (var i = 0; i < roleNames.Length; i++)
			{
				if (await roleManager.RoleExistsAsync(roleNames[i]))
				{
					continue;
				}
				await roleManager.CreateAsync(new()
				{
					Id = Guid.NewGuid().ToString(),
					Name = roleNames[i],
					NormalizedName = roleNames[i]!.ToUpper(cultureInfo),
					ConcurrencyStamp = Guid.NewGuid().ToString(),
				});
			}
		}

		public static async Task<UserManager<User>> SeedIdentityUsers(UserManager<User> userManager, params KeyValuePair<User, string>[] newUsers)
		{
			for (var i = 0; i < newUsers.Length; i++)
			{
				if (null != await userManager.FindByEmailAsync(newUsers[i].Key.Email!))
				{
					continue;
				}
				await userManager.CreateAsync(newUsers[i].Key, newUsers[i].Value);
			}
			return userManager;
		}

		public static async Task AssignUserToRole(UserManager<User> userManager, params KeyValuePair<User, string>[] usersAndRoles)
		{
			for (var i = 0; i < usersAndRoles.Length; i++)
			{
				if (await userManager.IsInRoleAsync(usersAndRoles[i].Key, usersAndRoles[i].Value))
				{
					continue;
				}
				await userManager.AddToRoleAsync(usersAndRoles[i].Key, usersAndRoles[i].Value);
			}
		}
	}
}
