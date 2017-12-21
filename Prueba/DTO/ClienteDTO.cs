using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.DTO
{
    public class ClienteDTO
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string RNC { get; set; }
        public string RazonSocial { get; set; }
        public string Posicion { get; set; }
        public string Comentarios { get; set; }
        public List<HttpPostedFileBase> file { get; set; }



    }
}