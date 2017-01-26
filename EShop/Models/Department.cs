using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }
        public bool DepartmentActive { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}