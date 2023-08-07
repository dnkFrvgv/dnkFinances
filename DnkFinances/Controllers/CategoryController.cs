using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using X.PagedList;

namespace DnkFinances.Controllers;
public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ApplicationDbContext _context;
    public CategoryController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(int currentPage = 1)
    {
         int numberItemsPerPage = 10;

        if(currentPage<1){
            currentPage = 1;
        }

        var categories = _context.TransactionCategories.ToList();
        var numberOfCategories = categories.Count();

        var pagedCategory = new Pagination(numberOfCategories, numberItemsPerPage);
        // ToPagedList(currentPage, pageSize);

        return View(categories);
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