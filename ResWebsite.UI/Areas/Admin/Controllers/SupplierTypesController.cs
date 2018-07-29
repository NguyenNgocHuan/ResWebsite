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
    public class SupplierTypesController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Admin/SupplierTypes
        public ActionResult Index()
        {
            return View(db.SupplierTypes.ToList());
        }

        // GET: Admin/SupplierTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierType supplierType = db.SupplierTypes.Find(id);
            if (supplierType == null)
            {
                return HttpNotFound();
            }
            return View(supplierType);
        }

        // GET: Admin/SupplierTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SupplierTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SupplierTypeId,SupplierName,Description,Status")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                db.SupplierTypes.Add(supplierType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplierType);
        }

        // GET: Admin/SupplierTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierType supplierType = db.SupplierTypes.Find(id);
            if (supplierType == null)
            {
                return HttpNotFound();
            }
            return View(supplierType);
        }

        // POST: Admin/SupplierTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierTypeId,SupplierName,Description,Status")] SupplierType supplierType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplierType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplierType);
        }

        // GET: Admin/SupplierTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupplierType supplierType = db.SupplierTypes.Find(id);
            if (supplierType == null)
            {
                return HttpNotFound();
            }
            return View(supplierType);
        }

        // POST: Admin/SupplierTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupplierType supplierType = db.SupplierTypes.Find(id);
            db.SupplierTypes.Remove(supplierType);
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
