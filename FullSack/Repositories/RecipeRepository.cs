using FullSack.Entities;
using FullSack.Persistent;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FullSack.Repositories
{
	public class RecipeRepository : Repository<Recipe>, IRecipeRepository
	{
		public RecipeRepository(IdentityDbContext<User> context) : base(context)
		{
		}

		public async Task<string?> FindSlugByIdAsync(string id)
		{
			var result = await base.DbSet.FindAsync(id);
			return (result != null) ? result.Slug : null;
		}

		public override async Task<Recipe?> GetByIdAsync(object id)
		{
			return await base.DbSet.Where(r => r.RecipeId == (string)id)
				.Include(r => r.IngredientNavProp)
				.Include(r => r.InstructionNavProp)
				.Include(r => r.UserNavProp)
				.FirstOrDefaultAsync();
		}

		public async Task<Recipe?> GetByUriSlugAsync(string slug)
		{
			return await base.DbSet.Where(r => r.Slug == slug)
				.Include(r => r.IngredientNavProp)
				.Include(r => r.InstructionNavProp)
				.Include(r => r.KeywordRecipeNavProp)
				.Include(r => r.UserNavProp)
				.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Recipe>> GetByFilterAsync(
			int pageIndex,
			int pageSize = 12,
			Expression<Func<Recipe, bool>>? filter = null,
			Func<IQueryable<Recipe>, IOrderedQueryable<Recipe>>? orderBy = null)
		{
			var query = base.DbSet.AsQueryable();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			query = query.Skip((pageIndex - 1) * pageSize)
				.Include(r => r.InstructionNavProp)
				.Include(r => r.IngredientNavProp)
				.Include(r => r.KeywordRecipeNavProp)
				.Include(r => r.UserNavProp)
				.Take(pageSize);

			return orderBy != null
				? await orderBy(query)
					.AsNoTrackingWithIdentityResolution()
					.ToListAsync()
				: await query
					.AsNoTrackingWithIdentityResolution()
					.ToListAsync();
		}
	}
}
