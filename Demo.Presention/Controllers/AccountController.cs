using Demo.DataAccessLayer.Models.IdentityModel;
using Demo.Presention.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var user = new ApplicationUser()
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName,
                        UserName = viewModel.UserName,
                        Email = viewModel.Email
                    };
                    var res = _userManager.CreateAsync(user, viewModel.Password).Result;
                    if (res.Succeeded)
                        return RedirectToAction("Login");
                    foreach (var error in res.Errors)
                        ModelState.AddModelError("", error.Description);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(viewModel);
        }
    }
}
