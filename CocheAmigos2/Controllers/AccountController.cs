using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using CocheAmigos2.Models;
using DataAccess.Business_Objects;
using DataAccess.Repositories;
using Statics;
using DataAccess.Utiles;
using CocheAmigos2.Handler;

namespace CocheAmigos2.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn
        private User_Repository _repository = new User_Repository(Constants.ConnectionString);
        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                int iduser = _repository.GetUserLogin(model.UserName, model.Password);
                if (iduser != 0)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {

                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El nombre de usuario o la contraseña especificados son incorrectos.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Intento de registrar al usuario
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword iniciará una excepción en lugar de
                // devolver false en determinados escenarios de error.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "La contraseña actual es incorrecta o la nueva contraseña no es válida.");
                }
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        // GET: /Account/RememberPassword

        public ActionResult RememberPassword()
        {
            RememberPasswordModel model = new RememberPasswordModel();
            return View(model);
        }

        //
        // POST: /Account/RememberPassword

        [HttpPost]
        public ActionResult RememberPassword(RememberPasswordModel model)
        {
            //Get the iduser with the email
            Users user = _repository.GetUserByEmail(model.Email);
            if (user.iduser != 0)
            {
                //Generate New Password
                string NewPassword = GenerateNewPassword.Generate();
                //Update to the user resetPassword in the database
                bool result = _repository.UpdateResetPassword(user.iduser, NewPassword);
                //Enviar email if has been updated correctly. 
                if (result)
                {

                    string url = Url.Action("ResetPassword", "Account", new System.Web.Routing.RouteValueDictionary(new { id = Crypto.Encrypt(user.iduser.ToString()), pw = Crypto.Encrypt(NewPassword) }), "http", Request.Url.Host);
                    string url1 = Server.UrlDecode(url);
                    SendEmail.SendForgotPassword(model.Email, NewPassword, url);

                    return View("ResetPasswordEmail");
                    //  return RedirectToAction("ResetPassword", new { id = Crypto.Encrypt(user.iduser.ToString()), pw = Crypto.Encrypt(NewPassword) });

                }
                else
                {
                    ViewBag.Confirmation = "No se ha reseteado la contraseña.";
                    return View(model);
                }



            }
            else
            {
                ViewBag.Confirmation = "El email" + model.Email + " no existe en COCHE AMIGO.";
                return View();
            }
        }

        public ActionResult ResetPassword(int id, string pw)
        {
                    Users user = _repository.GetUserEbyIdResetPassword(id, pw);
                    if (user.iduser == 0)
                    {

                        ViewBag.Confirmation = "El usuario no existe";
                        return View("ResetPasswordError");

                    }
                    else
                    {
                        return View();
                    }
            
        }

        //
        // POST: /Account/RememberPassword

        [HttpPost]
        public ActionResult ResetPassword(ResetPasswordModel model, int id, string pw)
        {
            Users user = _repository.GetUserEbyIdResetPassword(id, pw);
            if (user.iduser != 0)
            {
                //Check reset password

                _repository.UsersUpdatePassword(id, model.Password);
                FormsAuthentication.SetAuthCookie(user.name + user.surname, false);
                return RedirectToAction("Index","Home","");
            }
            else
            {
                ViewBag.Confirmation = "la contraseña que te hemos enviado por email no es la misma. ";
            }


            return View();
        }

        public ActionResult ResetPasswordEmail()
        {
            return View();
        }


        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // Vaya a http://go.microsoft.com/fwlink/?LinkID=177550 para
            // obtener una lista completa de códigos de estado.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "El nombre de usuario ya existe. Escriba un nombre de usuario diferente.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "Ya existe un nombre de usuario para esa dirección de correo electrónico. Escriba una dirección de correo electrónico diferente.";

                case MembershipCreateStatus.InvalidPassword:
                    return "La contraseña especificada no es válida. Escriba un valor de contraseña válido.";

                case MembershipCreateStatus.InvalidEmail:
                    return "La dirección de correo electrónico especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "La respuesta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "La pregunta de recuperación de la contraseña especificada no es válida. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.InvalidUserName:
                    return "El nombre de usuario especificado no es válido. Compruebe el valor e inténtelo de nuevo.";

                case MembershipCreateStatus.ProviderError:
                    return "El proveedor de autenticación devolvió un error. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                case MembershipCreateStatus.UserRejected:
                    return "La solicitud de creación de usuario se ha cancelado. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";

                default:
                    return "Error desconocido. Compruebe los datos especificados e inténtelo de nuevo. Si el problema continúa, póngase en contacto con el administrador del sistema.";
            }
        }
        #endregion
    }
}
