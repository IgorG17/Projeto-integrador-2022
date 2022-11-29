using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface IMedicamentoAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(MedicamentoViewModel medicamentoViewModel);
        MedicamentoViewModel ObterPorID(Guid id);
        IEnumerable<MedicamentoViewModel> ObterTodos();
        IEnumerable<MedicamentoViewModel> ObterTodosAtivos();
        void Atualizar(MedicamentoViewModel medicamentoViewModel);
        void Remover(Guid ID);
        MedicamentoViewModel ObterPorNomeMedicamento(string nomeMedicamento);
    }
}
