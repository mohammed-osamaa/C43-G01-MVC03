







using Demo.DataAccessLayer.Models.DepartmentsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        int add(T enity);
        int Delete(T entity);
        IEnumerable<T> GetAll(bool WithTtracking = false);
        IEnumerable<TResult> GetAll<TResult>(Expression<Func<T,TResult>> selector);
        IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate);
        T? GetById(int id);
        int Update(T entity);
    }
}
