using Demo.BusinessLogicLayer.DTOS.DepartmentDTOs;

namespace Demo.BusinessLogicLayer.Services.DepartmentServices
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