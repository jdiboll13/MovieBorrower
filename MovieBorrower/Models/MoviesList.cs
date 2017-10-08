using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class MoviesList
    {
        public class Item
        {
            public double vote_average { get; set; }
            public int vote_count { get; set; }
            public int Id { get; set; }
            public bool video { get; set; }
            public string media_type { get; set; }
            public string title { get; set; }
            public double popularity { get; set; }
            public string poster_path { get; set; }
            public string original_language { get; set; }
            public string original_title { get; set; }
            public List<int> genre_ids { get; set; }
            public string backdrop_path { get; set; }
            public bool adult { get; set; }
            public string overview { get; set; }
            public string release_date { get; set; }
            public string original_name { get; set; }
            public string name { get; set; }
            public string first_air_date { get; set; }
            public List<string> origin_country { get; set; }
        }

        public class Movies
        {
            public List<Item> items { get; set; }
        }
    }

}
