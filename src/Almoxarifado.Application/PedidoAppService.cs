using Almoxarifado.Application.Interface;
using Almoxarifado.Application.ViewModels;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Infra.Data;
using System;
using System.Collections.Generic;
using AutoMapper;
using Almoxarifado.Infra.Data.Repository;
using System.Data.Entity;
using System.Linq;

namespace Almoxarifado.Application
{
    public class PedidoAppService : IPedidoAppService
    {
        private readonly Repository<Pedido> _pedidoRepository = new Repository<Pedido>();
        private readonly AlmoxarifadoContext db = new AlmoxarifadoContext();
        //protected AlmoxarifadoContext Db;

        public void Adicionar(PedidoViewModel pedidoViewModel)
        {
            pedidoViewModel.dataEntradaPedido = DateTime.Now;
            var pedido = Mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);
            _pedidoRepository.Adicionar(pedido);
        }

        public void Atualizar(PedidoViewModel pedidoViewModel)
        {
            var pedido = Mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);
            _pedidoRepository.Atualizar(pedido);
        }

        public void Dispose()
        {
            _pedidoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        public void AtualizarStatusPedido(PedidoViewModel pedidoViewModel)
        {

            var pedido = Mapper.Map<PedidoViewModel, Pedido>(pedidoViewModel);

            var pesquisaDb = db.Pedidos.First(a => a.idPedido == pedido.idPedido);
            pesquisaDb.statusPedido = pedido.statusPedido;
            db.SaveChanges();
            //db.Pedidos.Attach(pedido);
            //entry.State = EntityState.Modified;
          

        }

        public PedidoViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<Pedido, PedidoViewModel>(_pedidoRepository.ObterPorID(id));
        }

        public IEnumerable<PedidoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoRepository.ObterTodos());
        }
        public IEnumerable<PedidoViewModel> ObterTodosPendentes()
        {
            return Mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoViewModel>>(_pedidoRepository.ObterTodos().Where(x => x.statusPedido == "Aguardando resposta"));
        }

    }
}