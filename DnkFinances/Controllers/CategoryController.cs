using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;
using Microsoft.AspNetCore.Mvc;
using DnkFinances.Enums;


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

    if (currentPage < 1)
    {
      currentPage = 1;
    }

    var categories = _context.TransactionCategories.ToList();
    var numberOfCategories = categories.Count();

    var pagedCategory = new Pagination(numberOfCategories, numberItemsPerPage);
    // ToPagedList(currentPage, pageSize);

    return View(categories);
  }

  public IActionResult CreateIncome()
  {
    var incomeModel = new TransactionCategory
    {
      Type = TransactionType.INCOME
    };

    return View("Create", incomeModel);
  }

  public IActionResult CreateExpense()
  {
    var expenseModel = new TransactionCategory
    {
      Type = TransactionType.EXPENSE
    };

    return View("Create", expenseModel);
  }

  [HttpPost]
  public IActionResult Create(TransactionCategory category)
  {
    if(ModelState.IsValid){

      _context.TransactionCategories.Add(category);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    return View("Create" ,category);
  }

  

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View("Error!");
  }
}