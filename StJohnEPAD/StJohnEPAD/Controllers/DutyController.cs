using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StJohnEPAD.Models;
using StJohnEPAD.DAL;

namespace StJohnEPAD.Controllers
{
    public class DutyController : Controller
    {
        private SJAContext db = new SJAContext();

        //
        // GET: /Duty/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAll()
        {
            return View(db.Duties.ToList());
        }

        //
        // GET: /Duty/Details/5

        public ActionResult Details(int id = 0)
        {
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        //
        // GET: /Duty/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Duty/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Duty duty)
        {
            if (ModelState.IsValid)
            {
                db.Duties.Add(duty);
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }

            return View(duty);
        }

        //
        // GET: /Duty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        //
        // POST: /Duty/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Duty duty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            return View(duty);
        }

        //
        // GET: /Duty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Duty duty = db.Duties.Find(id);
            if (duty == null)
            {
                return HttpNotFound();
            }
            return View(duty);
        }

        //
        // POST: /Duty/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duty duty = db.Duties.Find(id);
            db.Duties.Remove(duty);
            db.SaveChanges();
            return RedirectToAction("ViewAll");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}