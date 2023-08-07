using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Data;
using DnkFinances.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using X.PagedList;

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

    public IActionResult Income(int currentPage=1)
    {
        
        int pageSize = 10;

        if(currentPage<1){
            currentPage = 1;
        }

        var transactions = _context.TransactionCategories.ToPagedList(currentPage, pageSize);

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
