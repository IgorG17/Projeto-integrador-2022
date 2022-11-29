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

namespace Almoxarifado.UI.MVC.Controllers.Medicamento
{
   
    public class TipoMedicamentoController : Controller
    {
        private readonly TipoMedicamentoAppService _tipoMedicamentoAppService = new TipoMedicamentoAppService();  

        // GET: TipoMedicamento
        public ActionResult Index()
        {
            return View("~/Views/Medicamento/TipoMedicamento/Index.cshtml",_tipoMedicamentoAppService.ObterTodos());
        }

        // GET: TipoMedicamento/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMedicamentoViewModel tipoMedicamentoViewModel = _tipoMedicamentoAppService.ObterPorID(id);
            if (tipoMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Medicamento/TipoMedicamento/Details.cshtml",tipoMedicamentoViewModel);
        }

        // GET: TipoMedicamento/Create
        public ActionResult Create()
        {
            return View("~/Views/Medicamento/TipoMedicamento/Create.cshtml");
        }

        // POST: TipoMedicamento/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoMedicamento,nomeTipoMedicamento,flAtivo")] TipoMedicamentoViewModel tipoMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                tipoMedicamentoViewModel.idTipoMedicamento = Guid.NewGuid();
                _tipoMedicamentoAppService.Adicionar(tipoMedicamentoViewModel);
                return RedirectToAction("Index");
            }

            return View(tipoMedicamentoViewModel);
        }

        // GET: TipoMedicamento/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoMedicamentoViewModel tipoMedicamentoViewModel = _tipoMedicamentoAppService.ObterPorID(id.Value);
            if (tipoMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/Medicamento/TipoMedicamento/Edit.cshtml",tipoMedicamentoViewModel);
        }

        // POST: TipoMedicamento/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoMedicamentoViewModel tipoMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _tipoMedicamentoAppService.Atualizar(tipoMedicamentoViewModel);
                return RedirectToAction("Index");
            }
            return View(tipoMedicamentoViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tipoMedicamentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
