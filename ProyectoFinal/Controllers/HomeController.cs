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
using Newtonsoft.Json;

namespace ProyectoFinal.Controllers
{
 //   [Authorize]
    public class HomeController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();
        private RootObjectRepository repo = new RootObjectRepository();

        public ActionResult Index()
        {
            ViewBag.Message = "Sistema Medico Integrado";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[HttpPost]
        [AllowAnonymous]
        public ActionResult Insert(string data)
        {
            try
            {
                var recibido = JsonConvert.DeserializeObject<RootObject>(data);
                repo.InsertOrUpdate(recibido);
                repo.Save();
            }
            catch (Exception err)
            {
                return new JsonResult { Data = err.ToString() };
            }
            return new JsonResult { Data = "Eureka" };
        }

        public ActionResult EmergencyRoom()
        {
            Response.AddHeader("Refresh", "10");
            return View(db.RootObjects.ToList());
        }

    }
}
