using Demo.BusinessLogicLayer.DTOS;
using Demo.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Factory
{
    public static class DepartmentFactory
    {
        public static DepartmentDto ToDTO(this Department department)
        {
            return new DepartmentDto()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                Description =department.Description,
                DateOfCreation = DateOnly.FromDateTime(department.CreatedOn)
            };
        }
        public static DepartmentAllDetailsDTO TODetailsDto(this Department department)
        {
            return new DepartmentAllDetailsDTO()
            {
                Id= department.Id,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedBy=department.CreatedBy,
                CreatedOn=DateOnly.FromDateTime(department.CreatedOn),
                LastModifiedBy = department.LastModifiedBy,
                LastModifiedOn = DateOnly.FromDateTime(department.LastModifiedOn),
                IsDeleted=department.IsDeleted,
            };
        }
        public static Department ToEntity(this CreatedDepartmentDTO department)
        {
            return new Department() 
            {
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn =department.CreatedOn.ToDateTime(new TimeOnly()),
            };
        }
        public static Department ToEntity(this UpdatedDepartmentDTO department)
        {
            return new Department()
            {
                Id=department.ID,
                Name = department.Name,
                Code = department.Code,
                Description = department.Description,
                CreatedOn = department.CreatedOn.ToDateTime(new TimeOnly()),
            };
        }
    }
}
