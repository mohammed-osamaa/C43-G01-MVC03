using Demo.BusinessLogicLayer.DTOS;
using Demo.BusinessLogicLayer.Services;
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
        public IActionResult Create(CreatedDepartmentDTO createdDepartmentDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
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
            return View(createdDepartmentDTO);
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

        #region Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var Department = _departmentServices.GetById(id.Value);
            if (Department is null) return NotFound();
            var EditedDepartment = new DepartmentEditViewModel()
            {
                Name = Department.Name,
                Code = Department.Code,
                Description = Department.Description,
                CreatedOn = Department.CreatedOn
            };
            return View(EditedDepartment);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute]int id ,DepartmentEditViewModel viewModel)
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

    }
}
