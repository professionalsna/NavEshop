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
    public class InvoiceDetailController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: /InvoiceDetail/
        public ActionResult Index()
        {
            var invoicedetail = db.InvoiceDetail.Include(i => i.Invoice).Include(i => i.Product);
            return View(invoicedetail.ToList());
        }

        // GET: /InvoiceDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoicedetail = db.InvoiceDetail.Find(id);
            if (invoicedetail == null)
            {
                return HttpNotFound();
            }
            return View(invoicedetail);
        }

        // GET: /InvoiceDetail/Create
        public ActionResult Create()
        {
            ViewBag.InvoiceID = new SelectList(db.Invoice, "InvoiceID", "InvoiceID");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");
            return View();
        }

        // POST: /InvoiceDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InvoiceDetailID,InvoiceID,Qty,Price,ProductID")] InvoiceDetail invoicedetail)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetail.Add(invoicedetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InvoiceID = new SelectList(db.Invoice, "InvoiceID", "InvoiceID", invoicedetail.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", invoicedetail.ProductID);
            return View(invoicedetail);
        }

        // GET: /InvoiceDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoicedetail = db.InvoiceDetail.Find(id);
            if (invoicedetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvoiceID = new SelectList(db.Invoice, "InvoiceID", "InvoiceID", invoicedetail.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", invoicedetail.ProductID);
            return View(invoicedetail);
        }

        // POST: /InvoiceDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InvoiceDetailID,InvoiceID,Qty,Price,ProductID")] InvoiceDetail invoicedetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoicedetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvoiceID = new SelectList(db.Invoice, "InvoiceID", "InvoiceID", invoicedetail.InvoiceID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", invoicedetail.ProductID);
            return View(invoicedetail);
        }

        // GET: /InvoiceDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoicedetail = db.InvoiceDetail.Find(id);
            if (invoicedetail == null)
            {
                return HttpNotFound();
            }
            return View(invoicedetail);
        }

        // POST: /InvoiceDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetail invoicedetail = db.InvoiceDetail.Find(id);
            db.InvoiceDetail.Remove(invoicedetail);
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
