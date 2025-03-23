using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class GenericRepository<T>(ApplicationDbContext _dbContext) : IGenericRepository<T> where T : BaseEntity
    {
        public IEnumerable<T> GetAll(bool WithTtracking = false)
        {
            if (WithTtracking)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            var T = _dbContext.Set<T>().Find(id);
            return T;
        }
        public int add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            return _dbContext.SaveChanges();
        }
        public int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
