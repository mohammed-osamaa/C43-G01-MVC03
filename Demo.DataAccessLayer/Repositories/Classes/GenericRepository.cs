﻿using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll(bool WithTtracking = false)
        {
            if (WithTtracking)
                return _dbContext.Set<T>().Where(t=>t.IsDeleted != true).ToList();
            else
                return _dbContext.Set<T>().Where(t => t.IsDeleted != true).AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            var T = _dbContext.Set<T>().Find(id);
            return T;
        }
        public void add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector)
        {
            return _dbContext.Set<T>().Where(t => t.IsDeleted != true).Select(selector).ToList(); // Filter in IEnumerable<>
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList(); // Filter in IEnumerable<>
        }
    }
}
