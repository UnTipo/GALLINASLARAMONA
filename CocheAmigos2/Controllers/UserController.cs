using CocheAmigos2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CocheAmigos2.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserSimple user)
        {
            return View();
        }



    }
}
