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
using Almoxarifado.UI.MVC.Controllers;


namespace Almoxarifado.UI.MVC.Controllers.Medicamento
{
    public class CategoriaMedicamentoController : Controller
    {
        private readonly CategoriaMedicamentoAppService _categoriaMedicamentoAppService = new CategoriaMedicamentoAppService();
        private ApplicationDbContext db = new ApplicationDbContext();
        private UsuarioController usu = new UsuarioController();

        // GET: CategoriaMedicamento
        public ActionResult Index()
        {            
                return View("~/Views/Medicamento/CategoriaMedicamento/Index.cshtml", _categoriaMedicamentoAppService.ObterTodos());                  
        }

        // GET: CategoriaMedicamento/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaMedicamentoViewModel categoriaMedicamentoViewModel = db.CategoriaMedicamentoViewModels.Find(id);
            if (categoriaMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaMedicamentoViewModel);
        }

        // GET: CategoriaMedicamento/Create
        public ActionResult Create()
        {
            return View("~/Views/Medicamento/CategoriaMedicamento/Create.cshtml");
        }

        // POST: CategoriaMedicamento/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                categoriaMedicamentoViewModel.idCategoriaMedicamento = Guid.NewGuid();
                _categoriaMedicamentoAppService.Adicionar(categoriaMedicamentoViewModel);
                return RedirectToAction("Index");
            }

            return View(categoriaMedicamentoViewModel);
        }

        // GET: CategoriaMedicamento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaMedicamentoViewModel categoriaMedicamentoViewModel = _categoriaMedicamentoAppService.ObterPorID(id.Value);
            if (categoriaMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Medicamento/CategoriaMedicamento/Edit.cshtml", categoriaMedicamentoViewModel);
        }

        // POST: CategoriaMedicamento/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _categoriaMedicamentoAppService.Atualizar(categoriaMedicamentoViewModel);
                return RedirectToAction("Index");
            }
            return View(categoriaMedicamentoViewModel);
        }

        // GET: CategoriaMedicamento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaMedicamentoViewModel categoriaMedicamentoViewModel = db.CategoriaMedicamentoViewModels.Find(id);
            if (categoriaMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(categoriaMedicamentoViewModel);
        }

        // POST: CategoriaMedicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            CategoriaMedicamentoViewModel categoriaMedicamentoViewModel = db.CategoriaMedicamentoViewModels.Find(id);
            db.CategoriaMedicamentoViewModels.Remove(categoriaMedicamentoViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
