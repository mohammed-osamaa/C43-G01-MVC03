using Demo.BusinessLogicLayer.DTOS.EmployeeDTOs;
using Demo.BusinessLogicLayer.Services.DepartmentServices;
using Demo.BusinessLogicLayer.Services.EmployeeServices;
using Demo.Presention.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class EmployeeController(IEmployeeServices _employeeServices
        , ILogger<EmployeeController> _logger ,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index(string? EmployeeSearchName)
        {
            var Employess = _employeeServices.GetAllEmployees(EmployeeSearchName);
            ViewData["SearchName"] = EmployeeSearchName;
            return View(Employess);
        }

        #region Create Employee
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel Created)
        {
            if(ModelState.IsValid)
            {
                var createdEmployeeDTO = new CreatedEmployeeDTO()
                {
                    Name = Created.Name,
                    Address = Created.Address,
                    Age = Created.Age,
                    Salary = Created.Salary,
                    IsActive = Created.IsActive,
                    Email = Created.Email,
                    PhoneNumber = Created.PhoneNumber,
                    HiringDate = Created.HiringDate,
                    EmployeeType = Created.EmployeeType,
                    Gender = Created.Gender,
                    DepartmentId = Created.DepartmentId,
                    ProfileImage = Created.ProfileImage,
                };
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

            return View(Created);
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
            var EmployeeEdited = new EmployeeViewModel()
            {
                Name = emp.Name,
                Address = emp.Address,
                Age = emp.Age,
                Salary = emp.Salary,
                IsActive = emp.IsActive,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                HiringDate = emp.HiringDate,
                EmployeeType = emp.EmployeeType,
                Gender = emp.Gender,
                DepartmentId = emp.DepartmentId,
                ProfileImageName = emp.ProfileImageName,
            };
            return View(EmployeeEdited);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int? id ,EmployeeViewModel updated)
        {
            if(!id.HasValue) return BadRequest();   
            if(ModelState.IsValid)
            {
                var updatedEmployeeDTO = new UpdatedEmployeeDTO()
                {
                    Id = id.Value,
                    Name = updated.Name,
                    Address = updated.Address,
                    Age = updated.Age,
                    Salary = updated.Salary,
                    IsActive = updated.IsActive,
                    Email =updated.Email,
                    PhoneNumber = updated.PhoneNumber,
                    HiringDate = updated.HiringDate.ToDateTime(TimeOnly.MinValue),
                    EmployeeType = updated.EmployeeType,
                    Gender = updated.Gender,
                    DepartmentId = updated.DepartmentId,
                    ProfileImage = updated.ProfileImage,
                };
                try
                {
                    var res = _employeeServices.UpdateExistedEmployee(updatedEmployeeDTO);
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
