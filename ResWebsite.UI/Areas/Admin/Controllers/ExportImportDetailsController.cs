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
    public class ExportImportDetailsController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Admin/ExportImportDetails
        public ActionResult Index()
        {
            var exportImportDetails = db.ExportImportDetails.Include(e => e.ExportImport).Include(e => e.Item);
            return View(exportImportDetails.ToList());
        }

        // GET: Admin/ExportImportDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportDetail exportImportDetail = db.ExportImportDetails.Find(id);
            if (exportImportDetail == null)
            {
                return HttpNotFound();
            }
            return View(exportImportDetail);
        }

        // GET: Admin/ExportImportDetails/Create
        public ActionResult Create()
        {
            ViewBag.ExportImportId = new SelectList(db.ExportImports, "ExportImportId", "Description");
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName");
            return View();
        }

        // POST: Admin/ExportImportDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,ExportImportId,Quantity,Description")] ExportImportDetail exportImportDetail)
        {
            if (ModelState.IsValid)
            {
                db.ExportImportDetails.Add(exportImportDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExportImportId = new SelectList(db.ExportImports, "ExportImportId", "Description", exportImportDetail.ExportImportId);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName", exportImportDetail.ItemId);
            return View(exportImportDetail);
        }

        // GET: Admin/ExportImportDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportDetail exportImportDetail = db.ExportImportDetails.Find(id);
            if (exportImportDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExportImportId = new SelectList(db.ExportImports, "ExportImportId", "Description", exportImportDetail.ExportImportId);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName", exportImportDetail.ItemId);
            return View(exportImportDetail);
        }

        // POST: Admin/ExportImportDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,ExportImportId,Quantity,Description")] ExportImportDetail exportImportDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportImportDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExportImportId = new SelectList(db.ExportImports, "ExportImportId", "Description", exportImportDetail.ExportImportId);
            ViewBag.ItemId = new SelectList(db.Items, "ItemId", "ItemName", exportImportDetail.ItemId);
            return View(exportImportDetail);
        }

        // GET: Admin/ExportImportDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportDetail exportImportDetail = db.ExportImportDetails.Find(id);
            if (exportImportDetail == null)
            {
                return HttpNotFound();
            }
            return View(exportImportDetail);
        }

        // POST: Admin/ExportImportDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportImportDetail exportImportDetail = db.ExportImportDetails.Find(id);
            db.ExportImportDetails.Remove(exportImportDetail);
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
