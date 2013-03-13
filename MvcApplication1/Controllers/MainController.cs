using MvcApplication1.DataAccess;
using MvcApplication1.DataAccess.Business_Objects;
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
            City_Repository _repository = new City_Repository();
            List<City> cities = _repository.GetCitiesByPoblacion(query);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

    }
}
