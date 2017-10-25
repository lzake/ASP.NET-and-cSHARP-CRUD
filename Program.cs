using System;  
using System.Collections.Generic;  
using System.Data;  
using System.Data.Entity;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
  
namespace CRUDoperations.Controllers  
{  
    public class CRUDController : Controller  
    {  
        private TestDBEntities db = new TestDBEntities();  
  
        //  
        // GET: /CRUD/  
  
        public ActionResult Index()  
        {  
            return View(db.EMPLOYEEs.ToList());  
        }  
  
        //  
        // GET: /CRUD/Details/5  
  
        public ActionResult Details(string id = null)  
       {  
            EMPLOYEE employee = db.EMPLOYEEs.Find(id);  
            if  (employee == null)  
            {  
                return HttpNotFound();  
            }  
            return View(employee);  
        }  
  
        //  
        // GET: /CRUD/Create  
  
        public ActionResult Create()  
        {  
            return View();  
        }  
  
        //  
        // POST: /CRUD/Create  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public ActionResult Create(EMPLOYEE employee)  
        {  
            if (ModelState.IsValid)  
            {  
                db.EMPLOYEEs.Add(employee);  
                db.SaveChanges();  
                return RedirectToAction("Index");  
            }  
  
            return View(employee);  
        }  
  
        //  
        // GET: /CRUD/Edit/5  
  
        public ActionResult Edit(string id = null)  
        {  
            EMPLOYEE employee = db.EMPLOYEEs.Find(id);  
            if (employee == null)  
            {  
                return HttpNotFound();  
            }  
            return View(employee);  
        }  
  
        //  
        // POST: /CRUD/Edit/5  
  
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public ActionResult Edit(EMPLOYEE employee)  
        {  
            if (ModelState.IsValid)  
            {  
                db.Entry(employee).State = EntityState.Modified;  
                db.SaveChanges();  
                return RedirectToAction("Index");  
            }  
            return View(employee);  
        }  
  
        //  
        // GET: /CRUD/Delete/5  
  
        public ActionResult Delete(string id = null)  
        {  
            EMPLOYEE employee = db.EMPLOYEEs.Find(id);  
            if (employee == null)  
            {  
                return HttpNotFound();  
            }  
            return View(employee);  
        }  
  
        //  
        // POST: /CRUD/Delete/5  
  
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]  
        public ActionResult DeleteConfirmed(string id)  
        {  
            EMPLOYEE employee = db.EMPLOYEEs.Find(id);  
            db.EMPLOYEEs.Remove(employee);  
            db.SaveChanges();  
            return RedirectToAction("Index");  
        }  
  
        protected override void Dispose(bool disposing)  
        {  
            db.Dispose();  
            base.Dispose(disposing);  
        }  
    }  
}  