using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.DTOS.EmployeeDTOs
{
    public class EmployeeAllDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; } // User Id
        public DateTime CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User Id 
        public DateTime LastModifiedOn { get; set; } // Calculated on BD
        public bool IsDeleted { get; set; } // Flag to Soft Deleted
        public int? DepartmentId { get; set; }
        public string? Department { get; set; } // Department Name
    }
}
