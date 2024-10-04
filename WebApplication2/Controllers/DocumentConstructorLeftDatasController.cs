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
    public class DocumentConstructorLeftDatasController : Controller
    {
        private DocumentConstructorContext db = new DocumentConstructorContext();

        // GET: DocumentConstructorLeftDatas
        [HttpGet]
        public ActionResult Index()
        {
          
            return View(db.DocumentConstructorLeftDatas.ToList());
        }
   
       
        // GET: DocumentConstructorLeftDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorLeftData documentConstructorLeftData = db.DocumentConstructorLeftDatas.Find(id);
            if (documentConstructorLeftData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorLeftData);
        }

        // GET: DocumentConstructorLeftDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentConstructorLeftDatas/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create([Bind(Include = "DocumentConstructorLeftDataId,Title,Npp,SizeTitle")] DocumentConstructorLeftData documentConstructorLeftData)
        {
            if (ModelState.IsValid)
            {
              
                //var maxNpp = db.DocumentConstructorLeftDatas.Max(i => (int?)i.Npp) ?? 0;

                //// Устанавливаем Npp для нового элемента
                //newItem.Npp = maxNpp + 1;

                //// Добавляем новый элемент в контекст
                //db.DocumentConstructorLeftDatas.Add(newItem);
                //db.SaveChanges();




                db.DocumentConstructorLeftDatas.Add(documentConstructorLeftData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(documentConstructorLeftData);
        }

        // GET: DocumentConstructorLeftDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorLeftData documentConstructorLeftData = db.DocumentConstructorLeftDatas.Find(id);
            if (documentConstructorLeftData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorLeftData);
        }

        // POST: DocumentConstructorLeftDatas/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit([Bind(Include = "DocumentConstructorLeftDataId,Title,Npp,SizeTitle")] DocumentConstructorLeftData documentConstructorLeftData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentConstructorLeftData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(documentConstructorLeftData);
        }

        // GET: DocumentConstructorLeftDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentConstructorLeftData documentConstructorLeftData = db.DocumentConstructorLeftDatas.Find(id);
            if (documentConstructorLeftData == null)
            {
                return HttpNotFound();
            }
            return View(documentConstructorLeftData);
        }

        // POST: DocumentConstructorLeftDatas/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            DocumentConstructorLeftData documentConstructorLeftData = db.DocumentConstructorLeftDatas.Find(id);
            db.DocumentConstructorLeftDatas.Remove(documentConstructorLeftData);
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
        //DocumentConstructorLeftDatas/ChangeNpp/146
        public ActionResult ChangeNpp(int id)
        {
            var item = db.DocumentConstructorLeftDatas.Find(id);
            if (item != null)
            {
                var previousItem = db.DocumentConstructorLeftDatas
                    .Where(i => i.Npp <= item.Npp)
                    .OrderByDescending(i => i.Npp)
                    .FirstOrDefault();

                if (previousItem != null)
                {
                    // Меняем местами Npp
                    int tempNpp = item.Npp;
                    item.Npp = previousItem.Npp;
                    previousItem.Npp = tempNpp;

                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
