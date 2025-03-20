using Demo.DataAccessLayer.Data;

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