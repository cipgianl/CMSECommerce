﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMSECommerce.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize("Admin")]
public class DashboardController: Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
