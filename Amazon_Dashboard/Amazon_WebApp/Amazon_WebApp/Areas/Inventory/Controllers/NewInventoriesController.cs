using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AmazonModel.Inventory;

namespace Amazon_WebApp.Areas.Inventory.Controllers
{
    public class NewInventoriesController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory/NewInventories
        public ActionResult Index()
        {
            return View(db.NewInventories.ToList());
        }

        // GET: Inventory/NewInventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewInventory newInventory = db.NewInventories.Find(id);
            if (newInventory == null)
            {
                return HttpNotFound();
            }
            return View(newInventory);
        }

        // GET: Inventory/NewInventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/NewInventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseId,PurchaseDate,InventoryType,QuantityPurchased,Cost,PurchaseReason,PercentagePaid,ItemId,TheSourceId")] NewInventory newInventory)
        {
            if (ModelState.IsValid)
            {
                db.NewInventories.Add(newInventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newInventory);
        }

        // GET: Inventory/NewInventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewInventory newInventory = db.NewInventories.Find(id);
            if (newInventory == null)
            {
                return HttpNotFound();
            }
            return View(newInventory);
        }

        // POST: Inventory/NewInventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseId,PurchaseDate,InventoryType,QuantityPurchased,Cost,PurchaseReason,PercentagePaid,ItemId,TheSourceId")] NewInventory newInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newInventory);
        }

        // GET: Inventory/NewInventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewInventory newInventory = db.NewInventories.Find(id);
            if (newInventory == null)
            {
                return HttpNotFound();
            }
            return View(newInventory);
        }

        // POST: Inventory/NewInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewInventory newInventory = db.NewInventories.Find(id);
            db.NewInventories.Remove(newInventory);
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
