﻿using EcommerceApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Repositories.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAll();

        Task<List<T>> GetByQuery(Expression<Func<T, bool>> expression);

        Task<T> GetById(int id);

        Task<T> AddAsync(T entity);

        Task<int> RemoveAsync(T entity);

        Task<T> UpdateAsync(T entity); // finds with id and applies all field changes

        Task<int> SaveChangesAsync();
    }

}