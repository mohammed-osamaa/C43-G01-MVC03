using Demo.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices) : Controller
    {
        //BaseURl/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var Departments = _departmentServices.GetAllDepartment();
            return View(Departments);
        }
    }
}
