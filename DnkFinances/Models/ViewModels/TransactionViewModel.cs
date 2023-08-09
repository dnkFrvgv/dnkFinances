using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnkFinances.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DnkFinances.Models.ViewModels
{
    public class TransactionViewModel
    {
        public TransactionType Type { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        // public DateTime DateAdded { get; set; }

        // select lists
        public string SelectedStatusOption { get; set; }
        public List<SelectListItem> StatusSelectList { get; set; }
        public string SelectedAccountOption { get; set; }
        public List<SelectListItem> AccountSelectList { get; set; }
        public string SelectedCategoryOption {get;set;}
        public List<SelectListItem> CategorySelectList { get; set; }

    }
}