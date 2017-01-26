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
    public class PaymentModeController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: /PaymentMode/
        public ActionResult Index()
        {
            return View(db.PaymentMode.ToList());
        }

        // GET: /PaymentMode/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentmode = db.PaymentMode.Find(id);
            if (paymentmode == null)
            {
                return HttpNotFound();
            }
            return View(paymentmode);
        }

        // GET: /PaymentMode/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PaymentMode/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PaymentModeID,PaymentModeName,PaymentModeIsActive")] PaymentMode paymentmode)
        {
            if (ModelState.IsValid)
            {
                db.PaymentMode.Add(paymentmode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentmode);
        }

        // GET: /PaymentMode/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentmode = db.PaymentMode.Find(id);
            if (paymentmode == null)
            {
                return HttpNotFound();
            }
            return View(paymentmode);
        }

        // POST: /PaymentMode/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PaymentModeID,PaymentModeName,PaymentModeIsActive")] PaymentMode paymentmode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentmode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentmode);
        }

        // GET: /PaymentMode/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentMode paymentmode = db.PaymentMode.Find(id);
            if (paymentmode == null)
            {
                return HttpNotFound();
            }
            return View(paymentmode);
        }

        // POST: /PaymentMode/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentMode paymentmode = db.PaymentMode.Find(id);
            db.PaymentMode.Remove(paymentmode);
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
