using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface IPedidoAppService: IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(PedidoViewModel pedidoViewModel);
        PedidoViewModel ObterPorID(Guid id);
        IEnumerable<PedidoViewModel> ObterTodos();
        IEnumerable<PedidoViewModel> ObterTodosPendentes();
        void Atualizar(PedidoViewModel pedidoViewModel);        
        //EntradaEstoqueViewModel ObterNota(string notaEntradaEstoque);
    }
   
}
