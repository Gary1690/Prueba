using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.ResponseModel
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
       
    }
}