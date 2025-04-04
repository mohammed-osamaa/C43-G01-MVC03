using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.BusinessLogicLayer.Services.EmployeeServices;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices
        , ILogger<EmployeeController> _logger , IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var Employess = _employeeServices.GetAllEmployees();
            return View(Employess);
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedEmployeeDTO createdEmployeeDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var res = _employeeServices.CreateNewEmployee(createdEmployeeDTO);
                    if (res)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "The Employee Is Not Created !!");
                }
                catch (Exception ex)
                {
                    if(_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }

            return View(createdEmployeeDTO);
        }
        #endregion

        #region Details Of Employee
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeeServices.GetById(id.Value);
            if (emp != null)
                return View(emp);
            return NotFound();
        }
        #endregion
    }
}
