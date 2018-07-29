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
    public class ExportImportsController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Admin/ExportImports
        public ActionResult Index()
        {
            var exportImports = db.ExportImports.Include(e => e.Employee).Include(e => e.ExportImportType);
            return View(exportImports.ToList());
        }

        // GET: Admin/ExportImports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImport exportImport = db.ExportImports.Find(id);
            if (exportImport == null)
            {
                return HttpNotFound();
            }
            return View(exportImport);
        }

        // GET: Admin/ExportImports/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.ExportImportTypeId = new SelectList(db.ExportImportTypes, "ExportImportTypeId", "TypeName");
            return View();
        }

        // POST: Admin/ExportImports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExportImportId,EmployeeId,DateExportImport,ExportImportTypeId,Description")] ExportImport exportImport)
        {
            if (ModelState.IsValid)
            {
                db.ExportImports.Add(exportImport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", exportImport.EmployeeId);
            ViewBag.ExportImportTypeId = new SelectList(db.ExportImportTypes, "ExportImportTypeId", "TypeName", exportImport.ExportImportTypeId);
            return View(exportImport);
        }

        // GET: Admin/ExportImports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImport exportImport = db.ExportImports.Find(id);
            if (exportImport == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", exportImport.EmployeeId);
            ViewBag.ExportImportTypeId = new SelectList(db.ExportImportTypes, "ExportImportTypeId", "TypeName", exportImport.ExportImportTypeId);
            return View(exportImport);
        }

        // POST: Admin/ExportImports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExportImportId,EmployeeId,DateExportImport,ExportImportTypeId,Description")] ExportImport exportImport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exportImport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", exportImport.EmployeeId);
            ViewBag.ExportImportTypeId = new SelectList(db.ExportImportTypes, "ExportImportTypeId", "TypeName", exportImport.ExportImportTypeId);
            return View(exportImport);
        }

        // GET: Admin/ExportImports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExportImport exportImport = db.ExportImports.Find(id);
            if (exportImport == null)
            {
                return HttpNotFound();
            }
            return View(exportImport);
        }

        // POST: Admin/ExportImports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExportImport exportImport = db.ExportImports.Find(id);
            db.ExportImports.Remove(exportImport);
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
