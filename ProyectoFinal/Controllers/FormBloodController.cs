using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class FormBloodController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();

        //
        // GET: /FormBlood/

        public ActionResult Index()
        {
            return View(db.FormBlood.ToList());
        }

        //
        // GET: /FormBlood/Details/5

        public ActionResult Details(int id = 0)
        {
            FormBloodPressure formbloodpressure = db.FormBlood.Find(id);
            if (formbloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(formbloodpressure);
        }

        //
        // GET: /FormBlood/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FormBlood/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormBloodPressure formbloodpressure, int id = 0)
        {
            if (!ModelState.IsValid)
            {
                formbloodpressure.CreadoPor = User.Identity.Name;
                formbloodpressure.PatientModelId = id;
                db.FormBlood.Add(formbloodpressure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formbloodpressure);
        }

        //
        // GET: /FormBlood/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FormBloodPressure formbloodpressure = db.FormBlood.Find(id);
            if (formbloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(formbloodpressure);            
        }

        //
        // POST: /FormBlood/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormBloodPressure formbloodpressure)
        {
            if (!ModelState.IsValid)
            {
                formbloodpressure.CreadoPor = User.Identity.Name;
                db.Entry(formbloodpressure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formbloodpressure);
        }

        //
        // GET: /FormBlood/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FormBloodPressure formbloodpressure = db.FormBlood.Find(id);
            if (formbloodpressure == null)
            {
                return HttpNotFound();
            }
            return View(formbloodpressure);
        }

        //
        // POST: /FormBlood/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormBloodPressure formbloodpressure = db.FormBlood.Find(id);
            db.FormBlood.Remove(formbloodpressure);
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