using FullSack.Entities;
using System.Linq.Expressions;

namespace FullSack.Persistent
{
	public interface IRecipeRepository : IRepository<Recipe>
	{
		Task<string?> FindSlugByIdAsync(string id);
		Task<Recipe?> GetByUriSlugAsync(string slug);
		Task<IEnumerable<Recipe>> GetByFilterAsync(
			int pageIndex,
			int pageSize,
			Expression<Func<Recipe, bool>>? filter,
			Func<IQueryable<Recipe>, IOrderedQueryable<Recipe>>? orderBy);
	}
}
