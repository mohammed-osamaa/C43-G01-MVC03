using Demo.BusinessLogicLayer.DTOS;
using Demo.BusinessLogicLayer.DTOS.DepartmentDTOs;
using Demo.BusinessLogicLayer.Services.DepartmentServices;
using Demo.Presention.ViewModels.DepartmentViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Demo.Presention.Controllers
{
    public class DepartmentController(IDepartmentServices _departmentServices,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        //BaseURl/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "Welcome to Department Index Page (Bag)"; // Dynamic Determine DataType in Runtime 
                                                                        // Not Need Casting , Not Safe (Throw Exception)
            ViewData["Message"] = "Welcome to Department Index Page (Data)"; // Support Casting 
            
            ViewBag.Dept01 = new DepartmentDto() { Name = "Dept01"};
            ViewData["Dept02"] = new DepartmentDto() { Name = "Dept02" };
            var Departments = _departmentServices.GetAllDepartment();
            return View(Departments);
        }
        #region Create Department

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel Created)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdDepartmentDTO = new CreatedDepartmentDTO()
                    {
                        Name = Created.Name,
                        Code = Created.Code,
                        Description = Created.Description,
                        CreatedOn = Created.CreatedOn
                    };
                    bool result = _departmentServices.CreateNewDepartment(createdDepartmentDTO);
                    if (result)
                        return RedirectToAction(nameof(Index)); // Send requst to Index Action 
                    else
                        ModelState.AddModelError(string.Empty, "Department Is not Created !!");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                        _logger.LogError(ex.Message);
                }
            }
            return View(Created);
        }
        #endregion

        #region Department Details

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if(!id.HasValue) return BadRequest();

            var Department = _departmentServices.GetById(id.Value);

            if (Department is null)
                return NotFound();

            return View(Department);
        }
        #endregion

        #region Edit Department

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var Department = _departmentServices.GetById(id.Value);
            if (Department is null) return NotFound();
            var EditedDepartment = new DepartmentViewModel()
            {
                Name = Department.Name,
                Code = Department.Code,
                Description = Department.Description,
                CreatedOn = Department.CreatedOn
            };
            return View(EditedDepartment);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id ,DepartmentViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var UpdatedDepartment = new UpdatedDepartmentDTO()
                    {
                        ID = id,
                        Name = viewModel.Name,
                        Code = viewModel.Code,
                        Description = viewModel.Description,
                        CreatedOn = viewModel.CreatedOn,
                    };
                    bool result =_departmentServices.UpdateExistedDepartment(UpdatedDepartment);
                    if (result)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError(string.Empty, "Department Is not Updated.");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                        ModelState.AddModelError(string.Empty, ex.Message);
                    else
                    {
                        _logger.LogError(ex.Message);
                        return View("ErrorView",ex.Message);
                    }
                }
            }
            return View(viewModel);
        }
        #endregion

        #region Delete Department

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    if (!id.HasValue) return BadRequest();
        //    var Department = _departmentServices.GetById(id.Value);
        //    if (Department is null) return NotFound();
        //    return View(Department);
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool result = _departmentServices.DeleteExistedDepartment(id);
                if(result) return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError(string.Empty, "Department is not Deleted.");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex.Message);
                }
            }
        }
        #endregion
    }
}
