using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

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

       [NotMapped]
        private InvoiceDetail InvoiceLine { get; set; }

        [NotMapped]
        public Product Product { get; set; }
        //public int ProductID { get;set;}
        
        public Invoice()
        {
            InvoiceDetail= new HashSet<InvoiceDetail>();
   
        }
    }
}