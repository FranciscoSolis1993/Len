using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lennken.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public DateTime Creation { get; set; }
        public DateTime Modification { get; set;}

    }
}