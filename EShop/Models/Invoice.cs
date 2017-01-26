using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get;set; }
        public Decimal InvoiceTotal { get; set; }
        public bool IsPaid { get; set; }
        public int PaymentModeID { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetail { get; set; }
        
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public PaymentMode PaymentMode { get; set; }

    }
}