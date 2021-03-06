using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazonModel.Inventory;

namespace WebAppDashboard.Areas.Inventory.Controllers
{
    public class SalesOrdersController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/SalesOrders
        public ActionResult Index()
        {
            return View(db.SalesOrders.ToList());
        }

        // GET: Inventory/SalesOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: Inventory/SalesOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/SalesOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SalesId,OrderId,AltOrderId,PaymentStatus,PaymentsDate,PaymentTransactionId,OrderTotalPrice,PurchaseDate,BatchId,BuyerEmail,BuyerName,ShippingMethod,Status,ShippingCarrier,Tracking,PaymentMethod,MerchantId,MarketplaceId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.SalesOrders.Add(salesOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesOrder);
        }

        // GET: Inventory/SalesOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: Inventory/SalesOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SalesId,OrderId,AltOrderId,PaymentStatus,PaymentsDate,PaymentTransactionId,OrderTotalPrice,PurchaseDate,BatchId,BuyerEmail,BuyerName,ShippingMethod,Status,ShippingCarrier,Tracking,PaymentMethod,MerchantId,MarketplaceId")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesOrder);
        }

        // GET: Inventory/SalesOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: Inventory/SalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesOrder salesOrder = db.SalesOrders.Find(id);
            db.SalesOrders.Remove(salesOrder);
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
