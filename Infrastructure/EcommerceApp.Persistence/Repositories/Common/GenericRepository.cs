using EcommerceApp.Domain.Common;
using EcommerceApp.Persistence.DatabaseContext;
using ECommerceApp.Application.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace EcommerceApp.Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ECommerceDbContext dbContext;
        protected readonly DbSet<T> table;

        public GenericRepository(ECommerceDbContext dbContext)
        {
            this.dbContext = dbContext;
            table = this.dbContext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await table.AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await table.AddRangeAsync(entities);
            await SaveChangesAsync();
            return entities;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await table.FindAsync(id) ?? throw new NullReferenceException("Cannot find any record: " + id.ToString());
        }

        public async Task<List<T>> GetByQueryAsync(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var entity = await table.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException();

            table.Remove(entity);
            dbContext.Entry(entity).State = EntityState.Deleted;
            await SaveChangesAsync();
            return id;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            table.Update(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
            if (await SaveChangesAsync() > 0)
                return entity;
            else
                throw new DbUpdateException("Update exception");
        }

        public async Task<int> SaveChangesAsync()
        {
            if (dbContext.ChangeTracker.HasChanges())
            {
                // log the changes
            }

            return await dbContext.SaveChangesAsync();
        }

    }
}
