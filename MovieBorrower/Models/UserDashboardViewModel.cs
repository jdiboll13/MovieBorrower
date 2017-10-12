using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class UserDashboardViewModel
    {
        public int CheckoutId { get; set; }
        public Movies[] Movies { get; set; }
        public string UserId { get; set; }
        public DateTime PickUpDate { get; set; } = DateTime.Today.AddDays(5);
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(30);
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterPath { get; set; }
        public bool CheckedOut { get; set; }
    }
}


