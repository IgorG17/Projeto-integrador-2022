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

namespace Almoxarifado.UI.MVC.Controllers
{
    public class MedicamentoController : Controller
    {
        
        private readonly MedicamentoAppService _medicamentoAppService = new MedicamentoAppService();
        private readonly CategoriaMedicamentoAppService _categoriaMedicamentoAppService = new CategoriaMedicamentoAppService();
        private readonly TipoMedicamentoAppService _tipoMedicamentoAppService = new TipoMedicamentoAppService();

        private void AtivarViewBags()
        {
            ViewBag.CategoriaMedicamento = _categoriaMedicamentoAppService.ObterTodos();
            ViewBag.CategoriaMedicamentoAtivo = _categoriaMedicamentoAppService.ObterTodosAtivos();
            ViewBag.TipoMedicamento = _tipoMedicamentoAppService.ObterTodos();
            ViewBag.TipoMedicamentoAtivo = _tipoMedicamentoAppService.ObterTodosAtivos();
        }

        // GET: Medicamento
        public ActionResult Index()
        {
            AtivarViewBags();
            return View(_medicamentoAppService.ObterTodos());
        }

        // GET: Medicamento/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoViewModel medicamentoViewModel = _medicamentoAppService.ObterPorID(id);
            if (medicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicamentoViewModel);
        }

        // GET: Medicamento/Create
       
        public ActionResult Create()
        {
            
            AtivarViewBags();
            return View();
        }

        // POST: Medicamento/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedicamentoViewModel medicamentoViewModel)
        {
           

            AtivarViewBags();
            if (ModelState.IsValid)
            {
                medicamentoViewModel.idMedicamento = Guid.NewGuid();
                _medicamentoAppService.Adicionar(medicamentoViewModel);         
                return RedirectToAction("Index");
            }

            return View(medicamentoViewModel);
        }

        // GET: Medicamento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoViewModel medicamentoViewModel = _medicamentoAppService.ObterPorID(id.Value);
            if (medicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            AtivarViewBags();
            return View(medicamentoViewModel);
        }

        // POST: Medicamento/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MedicamentoViewModel medicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _medicamentoAppService.Atualizar(medicamentoViewModel);
                return RedirectToAction("Index");
            }
            return View(medicamentoViewModel);
        }

        // GET: Medicamento/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicamentoViewModel medicamentoViewModel = _medicamentoAppService.ObterPorID(id.Value);
            if (medicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(medicamentoViewModel);
        }

        // POST: Medicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _medicamentoAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _medicamentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
