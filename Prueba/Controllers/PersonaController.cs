using Prueba.Models;
using Prueba.ResponseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Prueba.Controllers
{
    public class PersonaController : Controller
    {
        public PruebaEntities dbc;
        // GET: Persona
        public PersonaController() {
            dbc = new PruebaEntities();
        }
        
        public JsonResult GetPersona(String cedula)
        {
            var response = new Response<Personas>();
            try
            {
                var persona = dbc.Personas.Where(x => x.Cedula == cedula).FirstOrDefault();
                response.Data = persona;
                response.Success = true;
            }
            catch (Exception)
            {
                response.Success = false;
                throw;
            }
            

           return Json(response, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbc?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}