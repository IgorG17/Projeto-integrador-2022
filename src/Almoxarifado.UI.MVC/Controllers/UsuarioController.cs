using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Almoxarifado.Application.ViewModels;
using Almoxarifado.UI.MVC.Models;
using Almoxarifado.Application;
using System.Web.Security;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Almoxarifado.UI.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioAppService _usuarioAppService = new UsuarioAppService();
        private RoleAppService _roleAppService = new RoleAppService();

        //public bool ValidarCookie()
        //{
            
        //    if (Request.Cookies["Login"] != null)
        //    {
        //        var value = Request.Cookies["Login"].Value;
        //        if (value != "Administrador")
        //        {
        //            return false; //False para outro
        //        }
        //    }
        //    return true; //True para admin
        //}
        private void AtivarViewBags()
        {
            ViewBag.Roles = _roleAppService.ObterTodos();
        }

        // GET: Usuario
    
        public ActionResult Index() //Login
        {
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UsuarioViewModel login) //Login
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            login = _usuarioAppService.ValidarUsuario(login); 
         

            if (login != null)
            {
                //HttpCookie UserCookie = new HttpCookie("Login");
                //UserCookie.Value = login.role.nomeRole;
                //UserCookie.Expires = DateTime.Now.AddHours(2);
                //Response.Cookies.Add(UserCookie);
                        
                if (login.flAtivo == false)
                {
                    ModelState.AddModelError("", "Usuário desativado.");
                }
              
                string returnUrl = "a";
                if (login.idRole.Value == new Guid("CDEF7890-ABCD-1334-ABCD-1234567890AB")) //Se for médico
                {
                    FormsAuthentication.SetAuthCookie(login.loginUsuario, login.lembrarMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {

                        return RedirectToAction("Index", "Home");
                        //return RedirectToAction("Index", "Estoque");
                    }
                    else
                    {
                       
                        return RedirectToAction("IndexMedico", "Pedido");  //Login Medico com Sucesso
                        //RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(login.loginUsuario, login.lembrarMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {

                        return RedirectToAction("Index", "Home");
                        //return RedirectToAction("Index", "Estoque");
                    }
                    else
                    {
                        
                                               
                        return RedirectToAction("Index", "Home"); //Login Admin com Sucesso
                        //RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Login inválido.");
            }

            return View(login);
        }

        //Get

        public ActionResult Listar()
        {
            return View(_usuarioAppService.ObterTodos());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = _usuarioAppService.ObterPorID(id);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }
            return View(usuarioViewModel);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {            
            AtivarViewBags();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                usuarioViewModel.idUsuario = Guid.NewGuid();
                _usuarioAppService.Adicionar(usuarioViewModel);
                return RedirectToAction("Listar");
            }
            else
            {
                return View(usuarioViewModel);
            }
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult LogOff()
        //{
        //    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        //    return RedirectToAction("Index", "Usuario");
        //}

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Usuario");
        }
        public ActionResult Edit(Guid? id)
        {
            AtivarViewBags();
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioViewModel usuarioViewModel = _usuarioAppService.ObterPorID(id.Value);
            if (usuarioViewModel == null)
            {
                return HttpNotFound();
            }

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                _usuarioAppService.Atualizar(usuarioViewModel);
                return RedirectToAction("Listar");
            }
            return View(usuarioViewModel);
        }

            // GET: Usuario/Delete/5
            //public ActionResult Delete(Guid? id)
            //{
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    UsuarioViewModel usuarioViewModel = db.UsuarioViewModels.Find(id);
            //    if (usuarioViewModel == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    return View(usuarioViewModel);
            //}

            //// POST: Usuario/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public ActionResult DeleteConfirmed(Guid id)
            //{
            //    UsuarioViewModel usuarioViewModel = db.UsuarioViewModels.Find(id);
            //    db.UsuarioViewModels.Remove(usuarioViewModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _usuarioAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
