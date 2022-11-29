using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface ITipoMedicamentoAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(TipoMedicamentoViewModel tipoMedicamentoViewModel);
        TipoMedicamentoViewModel ObterPorID(Guid id);
        IEnumerable<TipoMedicamentoViewModel> ObterTodos();
        IEnumerable<TipoMedicamentoViewModel> ObterTodosAtivos();
        void Atualizar(TipoMedicamentoViewModel tipoMedicamentoViewModel);
   
   
    }
}
