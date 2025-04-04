﻿using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Models.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.DTOS.EmployeeDTOs
{
    public class CreatedEmployeeDTO
    {
        //public string Name { get; set; } = null!;
        //public string? Address { get; set; }
        //public int Age { get; set; }
        //public decimal Salary { get; set; }
        //public bool IsActive { get; set; }
        //public string? Email { get; set; }
        //public string? PhoneNumber { get; set; }
        //public DateTime HiringDate { get; set; }
        //public Gender Gender { get; set; }
        //public EmployeeType EmployeeType { get; set; }
        //public int CreatedBy { get; set; } // User Id
        //public int LastModifiedBy { get; set; } // User Id 

        [Required]
        [MaxLength(50, ErrorMessage = "Max length should be 50 character")]
        [MinLength(5, ErrorMessage = "Min length should be 5 characters")]
        public string Name { get; set; } = null!;
        [Range(22, 30)]
        public int Age { get; set; }
        [RegularExpression("^[1-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}-[a-zA-Z]{5,10}$",
           ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
