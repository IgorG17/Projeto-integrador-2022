//using Almoxarifado.UI.MVC.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;

//namespace Almoxarifado.UI.MVC.Models
//{
//    public class ContaController : Controller
//    {
//        [AllowAnonymous]
//        public ActionResult Login(string returnUrl)
//        {
//            ViewBag.ReturnUrl = returnUrl;
//            return View();
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public ActionResult Login(LoginViewModel login, string returnUrl)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(login);
//            }

//            var usuario = UsuarioModel.ValidarUsuario(login.Usuario, login.Senha);

//            if (usuario != null)
//            {
//                FormsAuthentication.SetAuthCookie(usuario.Nome, login.LembrarMe);
//                if (Url.IsLocalUrl(returnUrl))
//                {
//                    return RedirectToAction("Index", "Estoque");
//                }
//                else
//                {
//                    RedirectToAction("Index", "Home");
//                }
//            }
//            else
//            {
//                ModelState.AddModelError("", "Login inválido.");
//            }

//            return View(login);
//        }

//        [HttpPost]
//        [AllowAnonymous]
//        public ActionResult LogOff()
//        {
//            FormsAuthentication.SignOut();
//            return RedirectToAction("Index", "Home");
//        }
//    }
//}