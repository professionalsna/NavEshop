﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public float Qty { get; set; }
        public float Price { get; set; }
        public int ProductID { get; set; }

        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
        

    }
}