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
    public class VitalSignController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();

        //
        // GET: /VitalSign/

        public ActionResult Index()
        {
            return View(db.FormVital.ToList());
        }

        //
        // GET: /VitalSign/Details/5

        public ActionResult Details(int id = 0)
        {
            FormVitalSigns formvitalsigns = db.FormVital.Find(id);
            if (formvitalsigns == null)
            {
                return HttpNotFound();
            }
            return View(formvitalsigns);
        }

        //
        // GET: /VitalSign/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VitalSign/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormVitalSigns formvitalsigns, int id = 0)
        {
            if (!ModelState.IsValid)
            {
                formvitalsigns.CreadoPor = User.Identity.Name;
                formvitalsigns.PatientModelId = id;
                db.FormVital.Add(formvitalsigns);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formvitalsigns);
        }

        //
        // GET: /VitalSign/Edit/5

        public ActionResult Edit(int id = 0)
        {
            FormVitalSigns formvitalsigns = db.FormVital.Find(id);
            if (formvitalsigns == null)
            {
                return HttpNotFound();
            }
            return View(formvitalsigns);
        }

        //
        // POST: /VitalSign/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormVitalSigns formvitalsigns)
        {
            if (!ModelState.IsValid)
            {
                formvitalsigns.CreadoPor = User.Identity.Name;
                db.Entry(formvitalsigns).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formvitalsigns);
        }

        //
        // GET: /VitalSign/Delete/5

        public ActionResult Delete(int id = 0)
        {
            FormVitalSigns formvitalsigns = db.FormVital.Find(id);
            if (formvitalsigns == null)
            {
                return HttpNotFound();
            }
            return View(formvitalsigns);
        }

        //
        // POST: /VitalSign/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FormVitalSigns formvitalsigns = db.FormVital.Find(id);
            db.FormVital.Remove(formvitalsigns);
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