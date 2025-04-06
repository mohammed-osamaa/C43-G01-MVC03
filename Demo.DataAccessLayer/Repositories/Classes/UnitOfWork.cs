using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public UnitOfWork(IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
        }
        public IEmployeeRepository EmployeeRepository => _employeeRepository;

        public IDepartmentRepository DepartmentRepository => _departmentRepository;

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
