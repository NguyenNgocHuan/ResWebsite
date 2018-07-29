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
    public class ExportImportTypesController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Admin/ExportImportTypes
        public ActionResult Index()
        {
            return View(db.ExportImportTypes.ToList());
        }

        // GET: Admin/ExportImportTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportType exportImportType = db.ExportImportTypes.Find(id);
            if (exportImportType == null)
            {
                return HttpNotFound();
            }
            return View(exportImportType);
        }

        // GET: Admin/ExportImportTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ExportImportTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExportImportTypeId,TypeName,Description")] ExportImportType exportImportType)
        {
            if (ModelState.IsValid)
            {
                db.ExportImportTypes.Add(exportImportType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exportImportType);
        }

        // GET: Admin/ExportImportTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportType exportImportType = db.ExportImportTypes.Find(id);
            if (exportImportType == null)
            {
                return HttpNotFound();
            }
            return View(exportImportType);
        }

        // POST: Admin/ExportImportTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExportImportTypeId,TypeName,Description")] ExportImportType exportImportType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportImportType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exportImportType);
        }

        // GET: Admin/ExportImportTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImportType exportImportType = db.ExportImportTypes.Find(id);
            if (exportImportType == null)
            {
                return HttpNotFound();
            }
            return View(exportImportType);
        }

        // POST: Admin/ExportImportTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportImportType exportImportType = db.ExportImportTypes.Find(id);
            db.ExportImportTypes.Remove(exportImportType);
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
