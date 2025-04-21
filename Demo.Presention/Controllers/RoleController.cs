using Demo.BusinessLogicLayer.DTOS.RoleDTOS;
using Demo.BusinessLogicLayer.Services.RoleServices;
using Demo.Presention.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class RoleController(IRoleServices _roleServices) : Controller
    {
        public IActionResult Index()
        {
            var roles = _roleServices.GetAllRoles();
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new CreatedRole
                {
                    Name = model.Name,
                };
                var result = _roleServices.CreateRole(role);
                if (result)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Failed to create role");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(string? id)
        {
            if (id == null) return BadRequest();
            var role = _roleServices.GetRoleById(id);
            if (role == null) return NotFound();
            return View(role);
        }
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (id == null) return BadRequest();
            var role = _roleServices.GetRoleById(id);
            if (role == null) return NotFound();
            return View(role);
        }
        [HttpPost]
        public IActionResult Edit(RoleDto model)
        {
            if (ModelState.IsValid)
            {
                var result = _roleServices.UpdateRole(model);
                if (result)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Failed to update role");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (id == null) return BadRequest();
            var role = _roleServices.GetRoleById(id);
            if (role == null) return NotFound();
            return View(role);
        }
        [HttpPost]
        public IActionResult Delete(RoleDto role)
        {
            if(ModelState.IsValid)
            {
                var result = _roleServices.DeleteRole(role);
                if (result)
                    return RedirectToAction("Index");
                ModelState.AddModelError("", "Failed to delete role");
            }
            return View(role);
        }
    }
}
