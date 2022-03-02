using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products
{
    public class ProductInfo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal discountPrice { get; set; }
    }
}
