using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Models.EmployeesModel;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class EmployeeRepository(ApplicationDbContext dbContext) : GenericRepository<Employee>(dbContext),IEmployeeRepository
    {
    }
}
