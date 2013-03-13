using MvcApplication1.DataAccess;
using MvcApplication1.DataAccess.Business_Objects;
using MvcApplication1.DataAccess.Repositories;
using MvcApplication1.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
            User_Repository _repository = new User_Repository();
            User _user = _repository.GetUserLogin(log.email, log.password);
           
           
            return View();
        }


    }
}
