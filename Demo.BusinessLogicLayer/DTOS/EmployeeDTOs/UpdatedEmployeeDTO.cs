﻿using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Models.Shared.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.DTOS.EmployeeDTOs
{
    public class UpdatedEmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int CreatedBy { get; set; } // User Id
        public int LastModifiedBy { get; set; } // User Id 
        public int? DepartmentId { get; set; } 
        public IFormFile? ProfileImage { get; set; }
    }
}
