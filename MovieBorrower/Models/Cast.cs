using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Cast
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("cast_id")]
        public long CastId { get; set; }

        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
}
