using Demo.DataAccessLayer.Models.EmployeesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeRepository :IGenericRepository<Employee>
    {

    }
}
