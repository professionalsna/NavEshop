using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class PaymentMode
    {
        public int PaymentModeID { get; set; }
        public string PaymentModeName { get; set; }
        public bool PaymentModeIsActive { get; set; }
    }
}