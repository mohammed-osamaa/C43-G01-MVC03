﻿using Microsoft.AspNetCore.Mvc;

namespace Demo.Presention.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
