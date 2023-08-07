using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnkFinances.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CurrentPage { get; set; }
        public int NumberItemsPerPage { get; set; }


        public Pagination(int totalItems, int currentPage, int numberItemsPerPage = 10)
        {
            int totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)numberItemsPerPage);

            
        }
    }
}