using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class DocumentConstructorsController : Controller
    {
        private DocumentConstructorContext db = new DocumentConstructorContext();

        // GET: DocumentConstructors
        public ActionResult Index()
        {
            return View(db.DocumentConstructors.ToList());
        }

        // GET: DocumentConstructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructor documentConstructor = db.DocumentConstructors.Find(id);
            if (documentConstructor == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructor);
        }

        // GET: DocumentConstructors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentConstructors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentConstructorId")] DocumentConstructor documentConstructor)
        {
            if (ModelState.IsValid)
            {
                db.DocumentConstructors.Add(documentConstructor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentConstructor);
        }

        // GET: DocumentConstructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructor documentConstructor = db.DocumentConstructors.Find(id);
            if (documentConstructor == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructor);
        }

        // POST: DocumentConstructors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentConstructorId")] DocumentConstructor documentConstructor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentConstructor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentConstructor);
        }

        // GET: DocumentConstructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructor documentConstructor = db.DocumentConstructors.Find(id);
            if (documentConstructor == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructor);
        }

        // POST: DocumentConstructors/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentConstructor documentConstructor = db.DocumentConstructors.Find(id);
            db.DocumentConstructors.Remove(documentConstructor);
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
