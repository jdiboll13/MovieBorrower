using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Actor
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }
        
        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
