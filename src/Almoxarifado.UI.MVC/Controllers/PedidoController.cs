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
    public class PedidoController : Controller
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

        // GET: Pedido
        [Authorize]
        public ActionResult Index()
        {
            AtivarViewBags();
            return View(_pedidoAppService.ObterTodos().OrderByDescending(x => x.numeroPedido));
        }

        public ActionResult IndexMedico()
        {
            AtivarViewBags();
            var teste = _pedidoAppService.ObterTodos().OrderByDescending(x => x.numeroPedido);
            //var usu = User.Identity.GetUsuarioNome();
            return View(teste); 
        }

        // GET: Pedido/Details/5
        [Authorize]
        public ActionResult Details(Guid id)
        {
            var Url = Request.Url.AbsoluteUri.Split('?')[0];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoViewModel pedidoViewModel = _pedidoAppService.ObterPorID(id);
            if (pedidoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(pedidoViewModel);
        }

        // GET: Pedido/Create
        [Authorize]
        public ActionResult Create()
        {
            AtivarViewBags();
            return View();
        }

        public ActionResult CreateMedico()
        {
            AtivarViewBags();
            return View();
        }

        // POST: Pedido/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                pedidoViewModel.idPedido = Guid.NewGuid();

                pedidoViewModel.statusPedido = "Aguardando resposta";

                pedidoViewModel.numeroPedido = _pedidoAppService.ObterTodos().Count();
                pedidoViewModel.numeroPedido++;

                _pedidoAppService.Adicionar(pedidoViewModel);
                return RedirectToAction("Index");
            }

            return View(pedidoViewModel);
        }

        // GET: Pedido/Edit/5
        [Authorize]
        public ActionResult Resposta(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoViewModel pedidoViewModel = _pedidoAppService.ObterPorID(id);
            if (pedidoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(pedidoViewModel);
        }

        // POST: Pedido/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Resposta(PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid)
            {
                var entrada = _pedidoAppService.ObterPorID(pedidoViewModel.idPedido);

                entrada.dataMudancaStatus = DateTime.Now;
                entrada.statusPedido = pedidoViewModel.statusPedido;
                if (entrada.statusPedido == "Aguardando resposta")
                {
                    entrada.numeroPedido = _pedidoAppService.ObterTodos().Count();
                    entrada.numeroPedido += entrada.numeroPedido;
                }

                _pedidoAppService.AtualizarStatusPedido(entrada);

                //if (entrada.statusPedido == "Entrou no Estoque")
                //{
                //    var entradaEstoque = new EntradaEstoqueViewModel();
                //    entradaEstoque.dataEntradaEstoque = entrada.dataMudancaStatus;
                //    entradaEstoque.idMedicamento = entrada.idMedicamento;
                //    entradaEstoque.quantidadeMedicamentoEstoque = entrada.quantidadeMedicamento;


                //    _entradaEstoqueAppService.Adicionar(entradaEstoque);
                //}
                return RedirectToAction("Index");
            }
            return View(pedidoViewModel);
        }

        // GET: Pedido/Delete/5


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pedidoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
