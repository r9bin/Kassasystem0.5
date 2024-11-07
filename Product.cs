using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassasystem0._5
{
    public class Product
    {
        public string Name { get; set; }
        public int IDnumber { get; set; }
        public decimal Price { get; set; }

        public string PriceTypeKg { get; set; } = "per kg";
        public int Ammount { get; set; }
    }
}
