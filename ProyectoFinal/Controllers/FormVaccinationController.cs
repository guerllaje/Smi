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
    public class FormVaccinationController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();

        //
        // GET: /FormVaccination/

        public ActionResult Index()
        {
            return View(db.FormVacci.ToList());
        }

        //
        // GET: /FormVaccination/Details/5

        public ActionResult Details(int id = 0)
        {
            FormVaccinations formvaccinations = db.FormVacci.Find(id);
            if (formvaccinations == null)
            {
                return HttpNotFound();
            }
            return View(formvaccinations);
        }

        //
        // GET: /FormVaccination/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /FormVaccination/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormVaccinations formvaccinations, int id = 0)
        {
            if (!ModelState.IsValid)
            {
                formvaccinations.CreadoPor = User.Identity.Name;
                formvaccinations.PatientModelId = id;
                db.FormVacci.Add(formvaccinations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formvaccinations);
        }

        //
        // GET: /FormVaccination/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FormVaccinations formvaccinations = db.FormVacci.Find(id);
            if (formvaccinations == null)
            {
                return HttpNotFound();
            }
            return View(formvaccinations);
        }

        //
        // POST: /FormVaccination/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormVaccinations formvaccinations)
        {
            if (!ModelState.IsValid)
            {
                formvaccinations.CreadoPor = User.Identity.Name;
                db.Entry(formvaccinations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formvaccinations);
        }

        //
        // GET: /FormVaccination/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FormVaccinations formvaccinations = db.FormVacci.Find(id);
            if (formvaccinations == null)
            {
                return HttpNotFound();
            }
            return View(formvaccinations);
        }

        //
        // POST: /FormVaccination/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormVaccinations formvaccinations = db.FormVacci.Find(id);
            db.FormVacci.Remove(formvaccinations);
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