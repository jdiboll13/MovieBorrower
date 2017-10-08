using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBorrower.Models
{
    public class Credits
    {
            public int Id { get; set; }
            public List<Cast> cast { get; set; }
    }
}
