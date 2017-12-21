using Prueba.DTO;
using Prueba.Models;
using Prueba.ResponseModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba.Controllers
{
    public class ClienteController : Controller
    {
        public PruebaEntities dbc;
        // GET: Persona
        public ClienteController()
        {
            dbc = new PruebaEntities();
        }

        // GET: Cliente
        public JsonResult AddCliente(ClienteDTO cliente)
        {
            var response  = new Response <Clientes>();
            try
            {
                Clientes cli = new Clientes();
                cli.Cedula = cliente.Cedula;
                cli.Nombre = cliente.Nombre;
                cli.Email = cliente.Email;
                cli.Telefono = cliente.Telefono;
                cli.Provincia = cliente.Provincia;
                cli.Municipio = cliente.Municipio;
                cli.RNC = cliente.RNC;
                cli.RazonSocial = cliente.RazonSocial;
                cli.Posicion = cliente.Posicion;
                cli.Comentarios = cliente.Comentarios;

                dbc.Entry(cli).State = System.Data.Entity.EntityState.Added;
                dbc.SaveChanges();
                if(cliente.file != null)
                {
                    foreach (var file in cliente.file)
                    {
                        MemoryStream target = new MemoryStream();
                        file.InputStream.CopyTo(target);
                        byte[] data = target.ToArray();
                        AdjuntoCliente adjunto = new AdjuntoCliente();
                        adjunto.Clientes = cli;
                        adjunto.Adjunto = data;

                        dbc.Entry(adjunto).State = System.Data.Entity.EntityState.Added;
                        dbc.SaveChanges();
                    }
                }
                
                response.Success = true;
            }
            catch (Exception e)
            {
                var response2 = new Response<Exception>();
                response2.Success = false;
                response2.Data = e;
                return Json(e, JsonRequestBehavior.AllowGet);
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