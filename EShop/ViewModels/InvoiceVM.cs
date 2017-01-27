﻿using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.ViewModels
{
    public class InvoiceVM
    {
        public int InvoiceID { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        
    }
}