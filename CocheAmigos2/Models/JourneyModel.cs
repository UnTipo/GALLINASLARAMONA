using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CocheAmigos2.Models
{
    public class JourneyModel
    {
    }

    public class JourneyMapModel
    {
        public string IdCityTo { get; set; }
       
        [Display(Name = "De")]
        public string CityTo { get; set; }
       
        public string IdCityFrom { get; set; }
        
        [Display(Name = "A")]
        public string CityFrom { get; set; }

        [Display(Name = "latitud")]
        public decimal latitudeCityTo { get; set; }

        [Display(Name = "longitud")]
        public decimal longitudeCityTo { get; set; }

        [Display(Name = "latitud")]
        public decimal latitudeCityFrom { get; set; }

        [Display(Name = "longitud")]
        public decimal longitudeCityFrom { get; set; }

    }
}