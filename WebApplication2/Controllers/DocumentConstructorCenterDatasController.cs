﻿using System;
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
    public class DocumentConstructorCenterDatasController : Controller
    {
        private DocumentConstructorContext db = new DocumentConstructorContext();

        // GET: DocumentConstructorCenterDatas
        public ActionResult Index()
        {
            return View(db.DocumentConstructorCenterDatas.ToList());
        }

        // GET: DocumentConstructorCenterDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorCenterData documentConstructorCenterData = db.DocumentConstructorCenterDatas.Find(id);
            if (documentConstructorCenterData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorCenterData);
        }

        // GET: DocumentConstructorCenterDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentConstructorCenterDatas/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocumentConstructorCenterDataId,Title,Npp,Size")] DocumentConstructorCenterData documentConstructorCenterData)
        {
            if (ModelState.IsValid)
            {
                db.DocumentConstructorCenterDatas.Add(documentConstructorCenterData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentConstructorCenterData);
        }

        // GET: DocumentConstructorCenterDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorCenterData documentConstructorCenterData = db.DocumentConstructorCenterDatas.Find(id);
            if (documentConstructorCenterData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorCenterData);
        }

        // POST: DocumentConstructorCenterDatas/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocumentConstructorCenterDataId,Title,Npp,Size")] DocumentConstructorCenterData documentConstructorCenterData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentConstructorCenterData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentConstructorCenterData);
        }

        // GET: DocumentConstructorCenterDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorCenterData documentConstructorCenterData = db.DocumentConstructorCenterDatas.Find(id);
            if (documentConstructorCenterData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorCenterData);
        }

        // POST: DocumentConstructorCenterDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentConstructorCenterData documentConstructorCenterData = db.DocumentConstructorCenterDatas.Find(id);
            db.DocumentConstructorCenterDatas.Remove(documentConstructorCenterData);
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
