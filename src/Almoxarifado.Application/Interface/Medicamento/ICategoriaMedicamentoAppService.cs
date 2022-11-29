using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface ICategoriaMedicamentoAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel);
        CategoriaMedicamentoViewModel ObterPorID(Guid id);
        IEnumerable<CategoriaMedicamentoViewModel> ObterTodos();
        IEnumerable<CategoriaMedicamentoViewModel> ObterTodosAtivos();
        void Atualizar(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel);
   
   
    }
}
