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
using AutoMapper;


namespace Almoxarifado.UI.MVC.Controllers
{
    public class EstoqueController : Controller
    {
        private EntradaEstoqueAppService _entradaEstoqueAppService = new EntradaEstoqueAppService();
        private readonly MedicamentoAppService _medicamentoAppService = new MedicamentoAppService();
        private readonly LocalMedicamentoAppService _localMedicamentoAppService = new LocalMedicamentoAppService();
        private BaixaEstoqueAppService _baixaEstoqueAppService = new BaixaEstoqueAppService();
        private TipoEntradaEstoqueAppService _tipoEntradaEstoqueAppService = new TipoEntradaEstoqueAppService();
        private readonly PedidoAppService _pedidoAppService = new PedidoAppService();

        private void AtivarViewBags()
        {
            ViewBag.Medicamento = _medicamentoAppService.ObterTodos();
            ViewBag.MedicamentoAtivo = _medicamentoAppService.ObterTodosAtivos();
            ViewBag.Local = _localMedicamentoAppService.ObterTodosAtivos();
            ViewBag.TipoEntradaEstoque = _tipoEntradaEstoqueAppService.ObterTodos();
        }

        // GET: EntradaEstoqueViewModels
        [Authorize]
        public ActionResult Index()
        {
            AtivarViewBags();
            //float total = 0;
            //var precoTotal = _entradaEstoqueAppService.ObterCustoMensal(total);
            return View(_entradaEstoqueAppService.ObterTodos().OrderBy(x => x.localMedicamento).ThenBy(x => x.quantidadeMedicamentoEstoque));
        }

        // GET: EntradaEstoqueViewModels/Details/5
        [Authorize]
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaEstoqueViewModel entradaEstoqueViewModel = _entradaEstoqueAppService.ObterPorID(id);
            if (entradaEstoqueViewModel == null)
            {
                return HttpNotFound();
            }
            return View(entradaEstoqueViewModel);
        }

        // GET: EntradaEstoqueViewModels/Create
        [Authorize]
        public ActionResult Create(Guid? idPedido)
        {
            AtivarViewBags();
            var url = (Request.Url.AbsoluteUri.Split('?')[0]);
            url = url.Substring(url.LastIndexOf('/') + 1);
            if (url.Length > 6)
            {
                EntradaEstoqueViewModel entradaEstoqueViewModel = new EntradaEstoqueViewModel();
                var dadosDoPedido = _pedidoAppService.ObterPorID(new Guid(url));
                entradaEstoqueViewModel.idMedicamento = dadosDoPedido.idMedicamento;
                entradaEstoqueViewModel.quantidadeMedicamentoEstoque = dadosDoPedido.quantidadeMedicamento;
                entradaEstoqueViewModel.idLocalMedicamento = dadosDoPedido.idLocalMedicamento;
                entradaEstoqueViewModel.idTipoEntradaEstoque = new Guid("CDEF7890-ABCD-1111-ABCD-1234567890AB");
                return View(entradaEstoqueViewModel);
            }

            return View();
        }

        // POST: EntradaEstoqueViewModels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(EntradaEstoqueViewModel entradaEstoqueViewModel)
        {
            //_entradaEstoqueAppService.ObterTodosPorNota(entradaEstoqueViewModel.notaEntradaEstoque);
            if (ModelState.IsValid)
            {
                if (entradaEstoqueViewModel.quantidadeMedicamentoEstoque < 0)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                };
                entradaEstoqueViewModel.idEntradaEstoque = Guid.NewGuid();
                _entradaEstoqueAppService.Adicionar(entradaEstoqueViewModel);
                return RedirectToAction("Index");
            }

            return View(entradaEstoqueViewModel);
        }

        // GET: EntradaEstoqueViewModels/Edit/5
        [Authorize]
        public ActionResult Baixa(Guid? id)
        {
            AtivarViewBags();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaEstoqueViewModel entradaEstoqueViewModel = _entradaEstoqueAppService.ObterPorID(id.Value);
            if (entradaEstoqueViewModel == null)
            {
                return HttpNotFound();
            }
            if (entradaEstoqueViewModel.quantidadeMedicamentoEstoque < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var medicamento = _medicamentoAppService.ObterPorID(entradaEstoqueViewModel.idMedicamento);
            var local = _localMedicamentoAppService.ObterPorID(entradaEstoqueViewModel.idLocalMedicamento);
            var baixa = new BaixaEstoqueViewModel();
            baixa.notaEntradaEstoque = entradaEstoqueViewModel.notaEntradaEstoque;
            baixa.idEntradaEstoque = entradaEstoqueViewModel.idEntradaEstoque;
            baixa.idMedicamento = entradaEstoqueViewModel.idMedicamento;
            baixa.nomeMedicamentoBaixa = medicamento.nomeMedicamento;
            baixa.dataEntradaEstoque = entradaEstoqueViewModel.dataEntradaEstoque;
            baixa.quantidadeMedicamentoEstoque = entradaEstoqueViewModel.quantidadeMedicamentoEstoque;
            baixa.idLocalMedicamento = entradaEstoqueViewModel.idLocalMedicamento;
            baixa.loteMedicamentoEstoque = entradaEstoqueViewModel.loteMedicamentoEstoque;
            baixa.nomeLocalBaixa = local.nomeLocalMedicamento;
            baixa.validadeMedicamento = entradaEstoqueViewModel.validadeMedicamento;


            return View(baixa);
        }

        // POST: EntradaEstoqueViewModels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Baixa(BaixaEstoqueViewModel baixaEstoqueViewModel)
        {
            baixaEstoqueViewModel.dataBaixaEstoque = DateTime.Now;
            if (ModelState.IsValid)
            {

                baixaEstoqueViewModel.dataEntradaEstoque = baixaEstoqueViewModel.dataEntradaEstoque;
                if (baixaEstoqueViewModel.quantidadeBaixa > 0)
                {
                    baixaEstoqueViewModel.quantidadeMedicamentoEstoque = baixaEstoqueViewModel.quantidadeMedicamentoEstoque - baixaEstoqueViewModel.quantidadeBaixa;
                    if (baixaEstoqueViewModel.quantidadeMedicamentoEstoque >= 0) // Quantidade em Estoque maior/igual do que 0 após a baixa
                    {
                        baixaEstoqueViewModel.quantidadeBaixa = 0;
                        _baixaEstoqueAppService.Adicionar(baixaEstoqueViewModel);

                        EntradaEstoqueViewModel entrada = _entradaEstoqueAppService.ObterPorID(baixaEstoqueViewModel.idEntradaEstoque);

                        entrada.quantidadeMedicamentoEstoque = baixaEstoqueViewModel.quantidadeMedicamentoEstoque;
                        if (entrada.quantidadeMedicamentoEstoque < baixaEstoqueViewModel.quantidadeBaixa)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        _entradaEstoqueAppService.AtualizarEstoqueSemRepository(entrada);


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Quantidade em Estoque menor do que 0
                    }
                }
                _baixaEstoqueAppService.Adicionar(baixaEstoqueViewModel);
                return RedirectToAction("Index");
            }
            return View(baixaEstoqueViewModel);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _entradaEstoqueAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
    public class LocalController : Controller
    {
        private LocalMedicamentoAppService _localMedicamentoAppService = new LocalMedicamentoAppService();

        // GET: EntradaEstoqueViewModels
        [Authorize]
        public ActionResult Index()
        {
            return View("~/Views/LocalMedicamento/Index.cshtml", _localMedicamentoAppService.ObterTodos());
        }

        // GET: EntradaEstoqueViewModels/Details/5
        [Authorize]
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalMedicamentoViewModel localMedicamentoViewModel = _localMedicamentoAppService.ObterPorID(id);
            if (localMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/LocalMedicamento/Details.cshtml", localMedicamentoViewModel);
        }

        // GET: EntradaEstoqueViewModels/Create
        [Authorize]
        public ActionResult Create()
        {
            return View("~/Views/LocalMedicamento/Create.cshtml");
        }

        // POST: EntradaEstoqueViewModels/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(LocalMedicamentoViewModel localMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                localMedicamentoViewModel.idLocalMedicamento = Guid.NewGuid();
                _localMedicamentoAppService.Adicionar(localMedicamentoViewModel);
                return RedirectToAction("Index");
            }

            return View(localMedicamentoViewModel);
        }

        // GET: EntradaEstoqueViewModels/Edit/5
        [Authorize]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocalMedicamentoViewModel localMedicamentoViewModel = _localMedicamentoAppService.ObterPorID(id.Value);
            if (localMedicamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View("~/Views/LocalMedicamento/Edit.cshtml", localMedicamentoViewModel);
        }

        // POST: EntradaEstoqueViewModels/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(LocalMedicamentoViewModel localMedicamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _localMedicamentoAppService.Atualizar(localMedicamentoViewModel);
                return RedirectToAction("Index");
            }
            return View(localMedicamentoViewModel);
        }
    }
}
