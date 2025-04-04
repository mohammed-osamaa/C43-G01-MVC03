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

        #region Edit Existed Employee
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var emp = _employeeServices.GetById(id.Value);
           
            if (emp == null) return NotFound();
            var EmployeeEdited = new UpdatedEmployeeDTO()
            {
                Id = emp.Id,
                Name = emp.Name,
                Address = emp.Address,
                Age = emp.Age,
                Salary = emp.Salary,
                IsActive = emp.IsActive,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                HiringDate = emp.HiringDate.ToDateTime(TimeOnly.MinValue),
                EmployeeType = emp.EmployeeType,
                Gender = emp.Gender,
            };
            return View(EmployeeEdited);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,UpdatedEmployeeDTO updated)
        {
            if(!id.HasValue || id != updated.Id) return BadRequest();   
            if(ModelState.IsValid)
            {
                try
                {
                    var res = _employeeServices.UpdateExistedEmployee(updated);
                    if (res)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Can't Update Employee !!");

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(updated);
        }
        #endregion

        #region Delete Employee
        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if(!id.HasValue) return BadRequest();   
        //    var Emp = _employeeServices.GetById(id.Value);
        //    if (Emp == null) return NotFound();
        //    return View(Emp);
        //}
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _employeeServices.DeleteExistedEmployee(id);
                if (res)
                    return RedirectToAction(nameof(Index));
                else
                    ModelState.AddModelError(string.Empty, "Can't Delete Employee !!");
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
                    _logger.LogError(ex.Message);
            }
            return View();
        }
        #endregion
    }
}
