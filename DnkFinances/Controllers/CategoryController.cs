using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DnkFinances.Controllers;
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult IncomeIndex()
    {
        return View();
    }

    public IActionResult ExpenseIndex()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View("Error!");
    }
}