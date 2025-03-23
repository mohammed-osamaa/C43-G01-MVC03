







using Demo.DataAccessLayer.Models.DepartmentsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        int add(T enity);
        int Delete(T entity);
        IEnumerable<T> GetAll(bool WithTtracking = false);
        T? GetById(int id);
        int Update(T entity);
    }
}
