using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Movie
    {
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }
        
        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        [JsonProperty("genres")]
        public Genre[] Genre { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }
        
        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }
        
        [JsonProperty("runtime")]
        public long Runtime { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("tagline")]
        public string Tagline { get; set; }
    }
}
