using System.Linq.Expressions;

namespace FullSack.Persistent
{
	public interface IRepository<TEntity> where TEntity : class
	{
		Task<bool> ExistsAsync(object id);

		Task<TEntity?> GetByIdAsync(object id);
		Task<IEnumerable<TEntity>> GetByFilterAsync(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string[]? includeProperties = null);

		void Add(TEntity entity);
		void Remove(TEntity entity);
		void Update(TEntity entity);
	}
}
