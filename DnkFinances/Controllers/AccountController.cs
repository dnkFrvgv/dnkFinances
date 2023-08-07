using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DnkFinances.Controllers;

public class AccountController : Controller
{
  private readonly ApplicationDbContext _context;

  public AccountController(ApplicationDbContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    return View(_context.Accounts.ToList());
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(Account account)
  {
    _context.Accounts.Add(account);
    _context.SaveChanges();

    return RedirectToAction("Index");
  }

  public IActionResult Edit(int id)
  {
    if (id <= 0)
    {
      return NotFound();
    }

    Account account = _context.Accounts.Find(id);

    if (account == null)
    {
      return NotFound();
    }

    return View(account);
  }


  [HttpPost]
  public IActionResult Edit(Account account)
  {
    if (ModelState.IsValid)
    {
      _context.Accounts.Update(account);
      _context.SaveChanges();

      return RedirectToAction("Index");
    }

    return View(account);
  }

  public IActionResult Details(int id)
  {
    var account = _context.Accounts.Find(id);

    if (account == null)
    {
      return Content("account not found");
    }

    return View(account);
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View("Error!");
  }
}
