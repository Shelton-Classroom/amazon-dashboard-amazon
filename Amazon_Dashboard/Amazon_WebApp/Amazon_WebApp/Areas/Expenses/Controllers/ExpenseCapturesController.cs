using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazonModel.Expenses;

namespace Amazon_WebApp.Areas.Expenses.Controllers
{
    public class ExpenseCapturesController : Controller
    {
        private ExpensesEntities db = new ExpensesEntities();

        // GET: Expenses/ExpenseCaptures
        public ActionResult Index()
        {
            return View(db.ExpenseCaptures.ToList());
        }

        // GET: Expenses/ExpenseCaptures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCapture expenseCapture = db.ExpenseCaptures.Find(id);
            if (expenseCapture == null)
            {
                return HttpNotFound();
            }
            return View(expenseCapture);
        }

        // GET: Expenses/ExpenseCaptures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expenses/ExpenseCaptures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseCaptureId,ExpenseDate,ExpenseAmount,MerchantId,ExpenseCode")] ExpenseCapture expenseCapture)
        {
            if (ModelState.IsValid)
            {
                db.ExpenseCaptures.Add(expenseCapture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expenseCapture);
        }

        // GET: Expenses/ExpenseCaptures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCapture expenseCapture = db.ExpenseCaptures.Find(id);
            if (expenseCapture == null)
            {
                return HttpNotFound();
            }
            return View(expenseCapture);
        }

        // POST: Expenses/ExpenseCaptures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExpenseCaptureId,ExpenseDate,ExpenseAmount,MerchantId,ExpenseCode")] ExpenseCapture expenseCapture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(expenseCapture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseCapture);
        }

        // GET: Expenses/ExpenseCaptures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExpenseCapture expenseCapture = db.ExpenseCaptures.Find(id);
            if (expenseCapture == null)
            {
                return HttpNotFound();
            }
            return View(expenseCapture);
        }

        // POST: Expenses/ExpenseCaptures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExpenseCapture expenseCapture = db.ExpenseCaptures.Find(id);
            db.ExpenseCaptures.Remove(expenseCapture);
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
