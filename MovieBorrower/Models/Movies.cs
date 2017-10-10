using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Movies
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
    }
}
