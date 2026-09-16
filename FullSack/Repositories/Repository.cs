using FullSack.Persistent;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FullSack.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		protected IdentityDbContext Context { get; private set; }
		protected DbSet<TEntity> DbSet { get; set; }

		public Repository(IdentityDbContext context)
		{
			this.Context = context;
			this.DbSet = this.Context.Set<TEntity>();
		}

		public virtual async Task<bool> ExistsAsync(object id)
		{
			return (await this.DbSet.FindAsync(id) == null) ? false : true;
		}

		public virtual async Task<TEntity?> GetByIdAsync(object id)
		{
			return await this.DbSet.FindAsync(id);
		}

		public virtual async Task<IEnumerable<TEntity>> GetByFilterAsync(
			Expression<Func<TEntity, bool>>? filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
			string[]? includeProperties = null)
		{
			IQueryable<TEntity> query = this.DbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			if (includeProperties != null)
			{
				foreach (var includeProp in includeProperties)
				{
					query = query.Include(includeProp.Trim());
				}
			}

			return orderBy != null
				? await orderBy(query).ToListAsync()
				: await query.ToListAsync();
		}


		public virtual void Add(TEntity entity)
		{
			this.DbSet.Add(entity);
		}

		public virtual void Remove(TEntity entity)
		{
			if (this.Context.Entry(entity).State == EntityState.Detached)
			{
				DbSet.Attach(entity);
			}
			this.DbSet.Remove(entity);
		}

		public virtual void Update(TEntity entity)
		{
			this.DbSet.Attach(entity);
			this.Context.Entry(entity).State = EntityState.Modified;
		}
	}
}
