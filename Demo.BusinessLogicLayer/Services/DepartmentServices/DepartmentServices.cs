using Demo.BusinessLogicLayer.DTOS.DepartmentDTOs;
using Demo.BusinessLogicLayer.Factory;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Services.DepartmentServices
{
    public class DepartmentServices(IDepartmentRepository _departmentRepository) : IDepartmentServices
    {
        // Get All
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var department = _departmentRepository.GetAll().ToList();
            return department.Select(D => D.ToDTO()).ToList();
        }
        // Get By Id
        public DepartmentAllDetailsDTO? GetById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return department?.TODetailsDto();
        }
        // Create New Department
        public bool CreateNewDepartment(CreatedDepartmentDTO dto)
        {
            var department = dto.ToEntity();
            var res = _departmentRepository.add(department);
            return res > 0 ? true : false;
        }
        // update
        public bool UpdateExistedDepartment(UpdatedDepartmentDTO dto)
        {
            var department = dto.ToEntity();
            var res = _departmentRepository.Update(department);
            return res > 0 ? true : false;
        }
        //Delete
        public bool DeleteExistedDepartment(int id)
        {
            var department = _departmentRepository.GetById(id);
            if (department != null)
            {
                var res = _departmentRepository.Delete(department);
                return res > 0 ? true : false;
            }
            else
                return false;
        }
    }
}
