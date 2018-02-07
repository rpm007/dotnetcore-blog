using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected DbSet<TEntity> Entities
        {
            get { return Context.Set<TEntity>(); }
        }


        public Repository(DbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
