using DataAccess;
using DataAccess.Business_Objects;
using Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMunicipios(string query)
        {
            City_Repository _repository = new City_Repository(Constants.ConnectionString);
            List<City> cities = _repository.GetCitiesByPoblacion(query);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}
