using Demo.BusinessLogicLayer.DTOS;

namespace Demo.BusinessLogicLayer.Services
{
    public interface IDepartmentServices
    {
        bool CreateNewDepartment(CreatedDepartmentDTO dto);
        bool DeleteExistedDepartment(int id);
        IEnumerable<DepartmentDto> GetAllDepartment();
        DepartmentAllDetailsDTO? GetById(int id);
        bool UpdateExistedDepartment(UpdatedDepartmentDTO dto);
    }
}