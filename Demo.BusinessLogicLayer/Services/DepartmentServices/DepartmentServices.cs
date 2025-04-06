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
    public class DepartmentServices(IUnitOfWork _unitOfWork) : IDepartmentServices
    {
        // Get All
        public IEnumerable<DepartmentDto> GetAllDepartment()
        {
            var department = _unitOfWork.DepartmentRepository.GetAll().ToList();
            return department.Select(D => D.ToDTO()).ToList();
        }
        // Get By Id
        public DepartmentAllDetailsDTO? GetById(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            return department?.TODetailsDto();
        }
        // Create New Department
        public bool CreateNewDepartment(CreatedDepartmentDTO dto)
        {
            var department = dto.ToEntity();
            _unitOfWork.DepartmentRepository.add(department);
            return _unitOfWork.SaveChanges() > 0 ? true : false;
        }
        // update
        public bool UpdateExistedDepartment(UpdatedDepartmentDTO dto)
        {
            var department = dto.ToEntity();
            _unitOfWork.DepartmentRepository.Update(department);
            return _unitOfWork.SaveChanges() > 0 ? true : false;

        }
        //Delete
        public bool DeleteExistedDepartment(int id)
        {
            var department = _unitOfWork.DepartmentRepository.GetById(id);
            if (department != null)
            {
                _unitOfWork.DepartmentRepository.Delete(department);
                return _unitOfWork.SaveChanges() > 0 ? true : false;
            }
            else
                return false;
        }
    }
}
