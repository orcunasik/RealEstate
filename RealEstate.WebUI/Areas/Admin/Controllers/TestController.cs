﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class TestController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}