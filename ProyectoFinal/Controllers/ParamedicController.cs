using Newtonsoft.Json;
using ProyectoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoFinal.Controllers
{
    public class ParamedicController : ApiController
    {
        private RootObjectRepository repo = new RootObjectRepository();

        // GET api/paramedic
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/paramedic/5
        public string Get(string data)
        {
            try
            {
                var recibido = JsonConvert.DeserializeObject<RootObject>(data);
                repo.InsertOrUpdate(recibido);
                repo.Save();
            }
            catch (Exception err)
            {
                return err.ToString();
            }            

            return "EUREKA!";
        }

        // POST api/paramedic
        public void Post([FromBody]string value)
        {
            
        }

        // PUT api/paramedic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/paramedic/5
        public void Delete(int id)
        {
        }
    }
}
