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
  
    public class HomeController : Controller
    {
        private DocumentConstructorContext db = new DocumentConstructorContext();
        
        public ActionResult Index()
        {
            
            return View(db.DocumentConstructorLeftDatas.ToList().OrderBy(i => i.Npp));
        }

        public ActionResult Edit()
        {
            return View(db.DocumentConstructorLeftDatas.ToList().OrderBy(i => i.Npp));
        }

       
    }
}