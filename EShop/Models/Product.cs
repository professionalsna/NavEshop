using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public float ProductStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }

   
}