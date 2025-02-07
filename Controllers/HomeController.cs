using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoCrudByme.Models;
using AdoCrudByme.Models.Domain;

namespace AdoCrudByme.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        OldStudConnectivityModel db=new OldStudConnectivityModel();

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AddOldStudModel obj)
        {
            if (ModelState.IsValid) 
            {
                db.AdOldStudent(obj);

            }
           return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.GetAll().Find(x=>x.Id==id));
        }
        [HttpPost]
        public ActionResult Edit(AddOldStudModel obj)
        {
                  db.Editt(obj);
            return RedirectToAction("Index");   
        }
        public ActionResult Deletett(int id) 
        {
                 db.deleteOld(id);
            return RedirectToAction("Index");   
        }
        public ActionResult contact()
        {
            return View();
        }



    }
}