using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Credits
    {
        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
