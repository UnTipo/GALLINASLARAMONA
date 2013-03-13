using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models.SearchJourney
{
    public class SearchJourney
    {

        public string IdCityTo { get; set; }
        [Display(Name = "De")]
        public string CityTo { get; set; }
        public string IdCityFrom { get; set; }
        [Display(Name = "A")]
        public string CityFrom { get; set; }

    }
}