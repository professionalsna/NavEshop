using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShop.Models;
using EShop.DAL;

namespace EShop.Controllers
{
    public class InvoiceController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: /Invoice/
        public ActionResult Index()
        {
            var invoice = db.Invoice
                .Include(i => i.Customer)
                .Include(i => i.Employee)
                .Include(i => i.PaymentMode).ToList();
            
            return View(invoice);
        }

        // GET: /Invoice/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: /Invoice/Create
        public ActionResult Create()
        {
            
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName");
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName");
            ViewBag.PaymentModeID = new SelectList(db.PaymentMode, "PaymentModeID", "PaymentModeName");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");

            return View(new Invoice());
        }

        // POST: /Invoice/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="InvoiceID,InvoiceDate,CustomerID,EmployeeID,InvoiceTotal,IsPaid,PaymentModeID")] Invoice invoice)
        public ActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoice.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", invoice.EmployeeID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentMode, "PaymentModeID", "PaymentModeName", invoice.PaymentModeID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");
            return View(invoice);
        }

        // GET: /Invoice/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);

            
               
            var invoic2 = db.Invoice.Include(b=>b.InvoiceDetail).ToString();
            // Load all blogs and related posts 
           



            if (invoice == null)
            {
                return HttpNotFound();
            }
            else
            {
                foreach (var i in invoice.InvoiceDetail)
                {
                    i.Product = db.Product.Find(i.ProductID);
                }
            }

            

        


            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", invoice.EmployeeID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentMode, "PaymentModeID", "PaymentModeName", invoice.PaymentModeID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");


            return View(invoice);
        }

        // POST: /Invoice/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InvoiceID,InvoiceDate,CustomerID,EmployeeID,InvoiceTotal,IsPaid,PaymentModeID")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "CustomerID", "CustomerName", invoice.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employee, "EmployeeID", "EmployeeName", invoice.EmployeeID);
            ViewBag.PaymentModeID = new SelectList(db.PaymentMode, "PaymentModeID", "PaymentModeName", invoice.PaymentModeID);
            return View(invoice);
        }

        // GET: /Invoice/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: /Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoice.Find(id);
            db.Invoice.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
