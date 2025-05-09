﻿using Demo.DataAccessLayer.Models.DepartmentsModel;
using Demo.DataAccessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Models.EmployeesModel
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email {  get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public int? DepartmentId { get; set; } // FK
        public virtual Department? Department { get; set; } 
        public string? ImageName { get; set; }
    }
}
