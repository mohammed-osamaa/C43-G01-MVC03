using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Models.DepartmentsModel;

namespace Demo.DataAccessLayer.Repositories
{
    public interface IDepartmentRepository
    {
        int add(Department department);
        int Delete(Department department);
        IEnumerable<Department> GetAll(bool WithTtracking = false);
        Department? GetById(int id);
        int Update(Department department);
    }
}