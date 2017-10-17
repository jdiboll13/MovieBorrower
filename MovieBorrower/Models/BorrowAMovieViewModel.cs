using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class BorrowAMovieViewModel
    {
        public int BorrowRecordId { get; set; }
        public int MovieId { get; set; }
        public Movie[] Movie { get; set; }
        public DateTime PickUpDate { get; set; } = DateTime.Today.AddDays(5);
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(30);
        public ApplicationUser ApplicationUser { get; set; }

    }
}
