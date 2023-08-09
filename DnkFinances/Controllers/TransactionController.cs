using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;
using DnkFinances.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DnkFinances.Enums;
using Microsoft.EntityFrameworkCore;

namespace DnkFinances.Controllers;


public class TransactionController : Controller
{
  private readonly ApplicationDbContext _context;

  public TransactionController(ApplicationDbContext context)
  {
    _context = context;
  }



  public IActionResult Index()
  {
    return View();
  }

  public IActionResult CreateIncome()
  {
    //fix later: put it all on like a createIncomeTransactionViewModel method

    // necessary list
    var accounts = _context.Accounts.ToList();
    var incomeCategories = _context.TransactionCategories.
        Where(t => t.Type == TransactionType.INCOME).ToList();

    // initializing view model
    var transactionViewModel = new TransactionViewModel();

    // initializing select lists
    transactionViewModel.AccountSelectList = new List<SelectListItem>();
    transactionViewModel.CategorySelectList = new List<SelectListItem>();
    transactionViewModel.StatusSelectList = new List<SelectListItem>();

    // populating select lists
    foreach (var account in accounts)
    {
      transactionViewModel.AccountSelectList.Add(new SelectListItem { Text = account.Name, Value = account.Id.ToString() });
    }

    foreach (var category in incomeCategories)
    {
      transactionViewModel.CategorySelectList.Add(new SelectListItem { Text = category.Title, Value = category.Id.ToString() });
    }

    foreach (var status in Enum.GetValues(typeof(TransactionStatus)))
    {
      transactionViewModel.StatusSelectList.Add(new SelectListItem
      {
        Text = status.ToString(),
        Value = ((int)status).ToString()
      });
    }

    // predifining type
    transactionViewModel.Type = TransactionType.INCOME;

    return View("Create", transactionViewModel);
  }

  public IActionResult CreateExpense()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(TransactionViewModel transactionViewModel)
  {
    if (ModelState.IsValid)
    {

      var accountSelected = _context.Accounts.Find(int.Parse(transactionViewModel.SelectedAccountOption));
      var categorySelected = _context.TransactionCategories.Find(int.Parse(transactionViewModel.SelectedCategoryOption));

      if (accountSelected == null)
      {
        ModelState.AddModelError("SelectedAccountOption", "Essa conta nao existe");
        return View(transactionViewModel);
      }

      if (categorySelected == null)
      {
        ModelState.AddModelError("SelectedCategoryOption", "Essa categoria nao existe");
        return View(transactionViewModel);
      }

      var transaction = new Transaction
      {
        Type = transactionViewModel.Type,
        Title = transactionViewModel.Title,
        Description = transactionViewModel.Description,
        Amount = transactionViewModel.Amount,
        Date = transactionViewModel.Date,
        DateAdded = DateTime.Now,
        Status = (TransactionStatus)Enum.Parse(typeof(TransactionStatus), transactionViewModel.SelectedStatusOption),
        // AccountId = ,
        Account = accountSelected,
        Category = categorySelected
        // CategoryId = ,
      };

      _context.Transactions.Add(transaction);
      _context.SaveChanges();

      return RedirectToAction("Income");
    }

    return View(transactionViewModel);
  }
  public IActionResult Income()
  {
    // int currentPage = 1

    // int pageSize = 10;

    // if(currentPage<1){
    //     currentPage = 1;
    // }

    var transactions = _context.Transactions.Include(t => t.Account).Include(t=>t.Category).ToList();

    // .ToPagedList(currentPage, pageSize);

    // var numberOfTransactions = transactions.Count();

    // IPagedList<Transaction> pagedTransactions = transactions.ToPagedList(currentPage, pageSize);

    return View(transactions);
  }

  public IActionResult Expense()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View("Error!");
  }
}
