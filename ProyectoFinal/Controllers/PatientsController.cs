using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();

        //
        // GET: /Patients/

        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        //
        // GET: /Patients/Details/5

        public ActionResult Details(int id = 0)
        {
            PatientModel patientmodel = db.Patients.Find(id);
            if (patientmodel == null)
            {
                return HttpNotFound();
            }
            return View(patientmodel);
        }

        //
        // GET: /Patients/Create

        public ActionResult Create()
        {
            // DropDown Tipos de Sangre-----------------------------------
            List<SelectListItem> blood = new List<SelectListItem>();
            blood.Add(new SelectListItem { Text = "", Value = "" });
            blood.Add(new SelectListItem { Text = "O+", Value = "O+" });
            blood.Add(new SelectListItem { Text = "O-", Value = "O-" });
            blood.Add(new SelectListItem { Text = "A+", Value = "A+" });
            blood.Add(new SelectListItem { Text = "A-", Value = "A-" });
            blood.Add(new SelectListItem { Text = "B+", Value = "B+" });
            blood.Add(new SelectListItem { Text = "B-", Value = "B-" });
            blood.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
            blood.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
            ViewBag.sangre = blood;
            //------------------------------------------------------------
            // DropDown Sexo-----------------------------------
            List<SelectListItem> sex = new List<SelectListItem>();
            sex.Add(new SelectListItem { Text = "", Value = "" });
            sex.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
            sex.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
            ViewBag.sexo = sex;
            //------------------------------------------------------------
            //DropDown Seguros--------------------------------------------
            List<SelectListItem> insurance = new List<SelectListItem>();
            insurance.Add(new SelectListItem { Text = "", Value = "" });
            insurance.Add(new SelectListItem { Text = "Ninguno", Value = "Ninguno" });
            insurance.Add(new SelectListItem { Text = "ARS Humano", Value = "Humano" });
            insurance.Add(new SelectListItem { Text = "La Colonial", Value = "La Colonial" });
            insurance.Add(new SelectListItem { Text = "Mapfre BHD", Value = "Mapfre" });
            insurance.Add(new SelectListItem { Text = "ARS Palic", Value = "Palic" });
            insurance.Add(new SelectListItem { Text = "ARS Senasa", Value = "Senasa" });
            insurance.Add(new SelectListItem { Text = "Seguros Universal", Value = "Universal" });
            ViewBag.seguro = insurance;
            //------------------------------------------------------------

            return View();
        }

        //
        // POST: /Patients/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PatientModel patientmodel)
        {
            if (!ModelState.IsValid)
            {
                patientmodel.CreadoPor = User.Identity.Name;
                db.Patients.Add(patientmodel);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = patientmodel.Id });
            }
            return View(patientmodel);
        }

        //
        // GET: /Patients/Edit/5


        public ActionResult Edit(int id = 0)
        {
            // DropDown Tipos de Sangre-----------------------------------
            List<SelectListItem> blood = new List<SelectListItem>();
            blood.Add(new SelectListItem { Text = "", Value = "" });
            blood.Add(new SelectListItem { Text = "O+", Value = "O+" });
            blood.Add(new SelectListItem { Text = "O-", Value = "O-" });
            blood.Add(new SelectListItem { Text = "A+", Value = "A+" });
            blood.Add(new SelectListItem { Text = "A-", Value = "A-" });
            blood.Add(new SelectListItem { Text = "B+", Value = "B+" });
            blood.Add(new SelectListItem { Text = "B-", Value = "B-" });
            blood.Add(new SelectListItem { Text = "AB+", Value = "AB+" });
            blood.Add(new SelectListItem { Text = "AB-", Value = "AB-" });
            ViewBag.sangre = blood;
            //------------------------------------------------------------
            // DropDown Sexo-----------------------------------
            List<SelectListItem> sex = new List<SelectListItem>();
            sex.Add(new SelectListItem { Text = "", Value = "" });
            sex.Add(new SelectListItem { Text = "Femenino", Value = "Femenino" });
            sex.Add(new SelectListItem { Text = "Masculino", Value = "Masculino" });
            ViewBag.sexo = sex;
            //------------------------------------------------------------
            //DropDown Seguros--------------------------------------------
            List<SelectListItem> insurance = new List<SelectListItem>();
            insurance.Add(new SelectListItem { Text = "", Value = "" });
            insurance.Add(new SelectListItem { Text = "Ninguno", Value = "Ninguno" });
            insurance.Add(new SelectListItem { Text = "ARS Humano", Value = "ARS Humano" });
            insurance.Add(new SelectListItem { Text = "La Colonial", Value = "La Colonial" });
            insurance.Add(new SelectListItem { Text = "Mapfre BHD", Value = "Mapfre BHD" });
            insurance.Add(new SelectListItem { Text = "ARS Palic", Value = "ARS Palic" });
            insurance.Add(new SelectListItem { Text = "ARS Senasa", Value = "ARS Senasa" });
            insurance.Add(new SelectListItem { Text = "Seguros Universal", Value = "Seguros Universal" });
            ViewBag.seguro = insurance;
            //------------------------------------------------------------

            PatientModel patientmodel = db.Patients.Find(id);
            if (patientmodel == null)
            {
                return HttpNotFound();
            }
            return View(patientmodel);
        }

        //
        // POST: /Patients/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PatientModel patientmodel)
        {
            if (ModelState.IsValid)
            {
                patientmodel.CreadoPor = User.Identity.Name;
                db.Entry(patientmodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = patientmodel.Id });
            }
            return View(patientmodel);
        }

        //
        // GET: /Patients/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PatientModel patientmodel = db.Patients.Find(id);
            if (patientmodel == null)
            {
                return HttpNotFound();
            }
            return View(patientmodel);
        }

        //
        // POST: /Patients/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientModel patientmodel = db.Patients.Find(id);
            db.Patients.Remove(patientmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //Search Box
        public ActionResult SearchPatients(string searchString)
        {
            ViewBag.isSearch = searchString;
            var patients = from m in db.Patients        
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(s =>
                    s.Nombre.Contains(searchString) ||
                    s.Apellido.Contains(searchString) ||
                    s.NumeroSeguroMedico.Contains(searchString) ||
                    (s.Nombre + " " + s.Apellido).Contains(searchString));
            }
            else
            {
                patients = new List<PatientModel>().AsQueryable();
            }

            return View(patients);
        }

        //Formulario de Presion sanguinea
        public ActionResult FormPresionSanguinea(int id)
        {
            var vm = db.FormBlood.Where(l => l.PatientModelId == id).AsEnumerable();
            return View(vm);
        }

        //Formulario de Signos Vitales
        public ActionResult FormSignosVitales(int id)
        {
            var sv = db.FormVital.Where(v => v.PatientModelId == id).AsEnumerable();
            return View(sv);
        }

        //Formulario de Vacunas
        public ActionResult FormVacunas(int id)
        {
            var va = db.FormVacci.Where(n => n.PatientModelId == id).AsEnumerable();
            return View(va);
        }

    }
}