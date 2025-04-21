using Demo.BusinessLogicLayer.DTOS.UserDTOS;
using Demo.BusinessLogicLayer.Services.UserServices;
using Demo.Presention.ViewModels.UserViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class UserController(IUserServices _userServices) : Controller
    {
        public IActionResult Index(string? Search)
        {
            var Users = _userServices.GetAllUsers(Search);
            ViewData["SearchName"] = Search;
            return View(Users);
        }
        public IActionResult Details(string? id)
        {
            if(string.IsNullOrEmpty(id))
                return BadRequest();
            var user = _userServices.GetUserById(id);
            if (user == null)
                return NotFound();
            return View(user);
        }
        [HttpGet]
        public IActionResult Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var user = _userServices.GetUserById(id);
            if (user == null)
                return NotFound();
            var updatedUser = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            return View(updatedUser);
        }
        [HttpPost]
        public IActionResult Edit(EditUserViewModel editUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var updatedUser = new UpdatedUserDto
                    {
                        Id = editUserViewModel.Id,
                        FirstName = editUserViewModel.FirstName,
                        LastName = editUserViewModel.LastName,
                        PhoneNumber = editUserViewModel.PhoneNumber,
                    };
                    var res = _userServices.UpdateUser(updatedUser);
                    if (res)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError("", "Failed to update user");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(editUserViewModel);
        }
        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var user = _userServices.GetUserById(id);
            if (user == null)
                return NotFound();
            var deletedUser = new DeletedUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
            };
            return View(deletedUser);
        }
        [HttpPost]
        public IActionResult Delete(DeletedUserViewModel deletedUserViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res = _userServices.DeleteUser(deletedUserViewModel.Id);
                    if (res)
                        return RedirectToAction(nameof(Index));
                    else
                        ModelState.AddModelError("", "Failed to Delete user");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(deletedUserViewModel);
        }
    }
}
