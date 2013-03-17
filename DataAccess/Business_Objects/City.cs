using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Business_Objects
{
    public class City
    {
        public int idmunicipio { get; set; }
        public string name { get; set; }
        public string comunidad { get; set; }
         public string provincia { get; set; }
        public decimal latitud { get; set; }
        public decimal longitud { get; set; }

    }
}