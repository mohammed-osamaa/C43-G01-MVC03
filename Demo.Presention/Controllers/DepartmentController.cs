using Demo.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class DepartmentController(IDepartmentServices departmentServices) : Controller
    {
        public IActionResult Index()
        {
            var Departments = departmentServices.GetAllDepartment();
            return View();
        }
    }
}
