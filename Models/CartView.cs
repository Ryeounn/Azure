using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sneker.Models
{
    public class CartView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Nullable<decimal> Unitprice { get; set; }
        public Nullable<int> amount { get; set; }
    }
}