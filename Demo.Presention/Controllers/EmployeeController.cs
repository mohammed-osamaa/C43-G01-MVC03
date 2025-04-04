using Demo.BusinessLogicLayer.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices) : Controller
    {
        public IActionResult Index()
        {
            var Employess = _employeeServices.GetAllEmployees();
            return View(Employess);
        }
    }
}
