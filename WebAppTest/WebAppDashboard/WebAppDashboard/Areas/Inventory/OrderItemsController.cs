using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazonModel.Inventory;

namespace WebAppDashboard.Areas.Inventory
{
    public class OrderItemsController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/OrderItems
        public ActionResult Index()
        {
            return View(db.OrderItems.ToList());
        }

        // GET: Inventory/OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: Inventory/OrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderItemId,OrderItemNumberId,SKU,CurrencyType,CurrencyConversionDate,CurrencyConversionRate,Location,UPC,ProductId,ItemName,ListingId,Price,UnitTax,ShippingFee,ShippingFeeTax,QuantityPurchased,TotalPrice,ItemFees,ItemCondition,ItemSource,ItemCost,OriginalAmount")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderItem);
        }

        // GET: Inventory/OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: Inventory/OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderItemId,OrderItemNumberId,SKU,CurrencyType,CurrencyConversionDate,CurrencyConversionRate,Location,UPC,ProductId,ItemName,ListingId,Price,UnitTax,ShippingFee,ShippingFeeTax,QuantityPurchased,TotalPrice,ItemFees,ItemCondition,ItemSource,ItemCost,OriginalAmount")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderItem);
        }

        // GET: Inventory/OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: Inventory/OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
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
