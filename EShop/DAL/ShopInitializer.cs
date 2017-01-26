using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShop.DAL
{
    public class ShopInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            var categories = new List<Category>
            {
            new Category{CategoryName="Stationary"},
            new Category{CategoryName="Sports"},
            new Category{CategoryName="Mobiles"}
            };

            categories.ForEach(c => context.Category.Add(c));
            context.SaveChanges();

            var products = new List<Product>
            {
            new Product{ProductName="Pen", ProductPrice=30.0f, ProductStock=50.0f, CategoryID=1},
            new Product{ProductName="Pencil", ProductPrice=30.0f, ProductStock=50.0f, CategoryID=1},
            new Product{ProductName="Ball", ProductPrice=3.0f, ProductStock=50.0f, CategoryID=2},
            new Product{ProductName="Bat", ProductPrice=10.0f, ProductStock=50.0f, CategoryID=2},
            new Product{ProductName="Galaxy S4", ProductPrice=400.0f, ProductStock=50.0f, CategoryID=3},
            new Product{ProductName="IPhone 6S", ProductPrice=600.0f, ProductStock=50.0f, CategoryID=3}
            };

            
         //   products.ForEach(p => context.Product.Add(p));
         //   context.SaveChanges();

         //   var dept = new List<Department>
         //{
         //    new Department{DepartmentName="Administration", DepartmentActive=true},
         //    new Department{DepartmentName="IT", DepartmentActive=true},
         //    new Department{DepartmentName="Security", DepartmentActive=true}
         //};
         //   dept.ForEach(d => context.Department.Add(d));
         //   context.SaveChanges();


         //   var emp = new List<Employee>
         //   {
         //       new Employee {EmployeeName="ABC",EmployeePhone="123456", DepartmentID=1},
         //       new Employee {EmployeeName="DEF",EmployeePhone="123456", DepartmentID=2},
         //       new Employee {EmployeeName="GHI",EmployeePhone="123456", DepartmentID=3}
         //   };

         //   emp.ForEach(e => context.Employee.Add(e));
         //   context.SaveChanges();
           

        }
    }
}