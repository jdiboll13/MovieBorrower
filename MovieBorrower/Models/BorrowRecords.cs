using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class BorrowRecords
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public DateTime PickUpDate { get; set; } = DateTime.Today.AddDays(5);
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(30);
        public ApplicationUser ApplicationUser { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
