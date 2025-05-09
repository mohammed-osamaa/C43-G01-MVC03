﻿using Demo.DataAccessLayer.Models.IdentityModel;
using Demo.Presention.Utilities;
using Demo.Presention.ViewModels.AccountViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Threading.Tasks;

namespace Demo.Presention.Controllers
{
    public class AccountController(UserManager<ApplicationUser> _userManager , SignInManager<ApplicationUser> _signInManager) : Controller
    {
        #region Registeration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
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
        #endregion

        #region Login And Logout

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByEmailAsync(model.Email).Result;
                    if(user != null)
                    {
                        var res = _userManager.CheckPasswordAsync(user, model.Password).Result;
                        if (res)
                        {
                            // Sign In
                            var signInResult = _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false).Result;
                            if (signInResult.IsNotAllowed)
                                // Redirect to the home page or any other page
                                ModelState.AddModelError("", "Account Is NOt Allowed.");
                            else if (signInResult.IsLockedOut)
                                ModelState.AddModelError("", "Account Is Locked Out.");
                            else
                                return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
                    ModelState.AddModelError("", "Invalid Login");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                _signInManager.SignOutAsync();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction(nameof(HomeController.Index) , "Home");
        }

        #endregion

        #region Forget Password

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userManager.FindByEmailAsync(model.Email).Result;
                    if (user != null)
                    {
                        // Generate Token
                        var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                        var Link = Url.Action("ResetPassword", "Account", new { email = model.Email , token }, Request.Scheme);
                        var Email = new Email()
                        {
                            To = model.Email,
                            Subject = "Reset Password",
                            Body = Link
                        };
                        // Send Email
                        EmailSettings.SendEmail(Email);
                        return RedirectToAction(nameof(CheckYourInBox));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(nameof(ForgetPassword),model);
        }


        [HttpGet]
        public IActionResult CheckYourInBox() => View();

        [HttpGet]
        public IActionResult ResetPassword(string email , string token) 
        {
            TempData["Email"] = email;
            TempData["Token"] = token;
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var email = TempData["Email"] as string ?? "";
                    var token = TempData["token"] as string ?? "";

                    var user = _userManager.FindByEmailAsync(email).Result;
                    if(user != null)
                    {
                        var res = _userManager.ResetPasswordAsync(user,token,model.Password).Result;
                        if(res.Succeeded)
                            return RedirectToAction(nameof(Login));
                        else
                            foreach (var error in res.Errors)
                                ModelState.AddModelError("", error.Description);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
        #endregion


    }
}
