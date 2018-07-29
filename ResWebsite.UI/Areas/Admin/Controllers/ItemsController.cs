using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResWebsite.DAL.Entity;

namespace ResWebsite.UI.Areas.Admin.Controllers
{
    public class ItemsController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Admin/Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.WarehouseType);
            return View(items.ToList());
        }

        // GET: Admin/Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Admin/Items/Create
        public ActionResult Create()
        {
            ViewBag.WarehouseTypeId = new SelectList(db.WarehouseTypes, "WarehouseTypeId", "WarehouseName");
            return View();
        }

        // POST: Admin/Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,WarehouseTypeId,ItemName,Quantity,Unit,Price,ExpiryDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WarehouseTypeId = new SelectList(db.WarehouseTypes, "WarehouseTypeId", "WarehouseName", item.WarehouseTypeId);
            return View(item);
        }

        // GET: Admin/Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.WarehouseTypeId = new SelectList(db.WarehouseTypes, "WarehouseTypeId", "WarehouseName", item.WarehouseTypeId);
            return View(item);
        }

        // POST: Admin/Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,WarehouseTypeId,ItemName,Quantity,Unit,Price,ExpiryDate")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WarehouseTypeId = new SelectList(db.WarehouseTypes, "WarehouseTypeId", "WarehouseName", item.WarehouseTypeId);
            return View(item);
        }

        // GET: Admin/Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Admin/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
