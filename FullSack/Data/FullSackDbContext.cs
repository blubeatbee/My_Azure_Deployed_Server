using FullSack.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullSack.Data
{
	public class FullSackDbContext : IdentityDbContext<User>
	{
		public FullSackDbContext(DbContextOptions<FullSackDbContext> options) : base(options)
		{
		}

		public virtual DbSet<Ingredient> Ingredients {get; set; }
		public virtual DbSet<Instruction> Instructions {get; set; }
		public virtual DbSet<Keyword> Keywords {get; set; }
		public virtual DbSet<KeywordCategory> KeywordCategories {get; set; }
		public virtual DbSet<Measurement> Measurements {get; set; }
		public virtual DbSet<Recipe> Recipes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
