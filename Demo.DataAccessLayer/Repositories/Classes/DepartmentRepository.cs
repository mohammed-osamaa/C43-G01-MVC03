using Demo.DataAccessLayer.Data;
using Demo.DataAccessLayer.Models.DepartmentsModel;
using Demo.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : GenericRepository<Department>(dbContext), IDepartmentRepository
    {

    }
}
