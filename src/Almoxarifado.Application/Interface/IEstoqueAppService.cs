using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface IEntradaEstoqueAppService: IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(EntradaEstoqueViewModel entradaEstoqueViewModel);
        EntradaEstoqueViewModel ObterPorID(Guid id);
        IEnumerable<EntradaEstoqueViewModel> ObterTodos();
 
        float ObterCustoMensal(float total1);
        float ObterCustoAnual(float total1);
        void Atualizar(EntradaEstoqueViewModel entradaEstoqueViewModel);

        void AtualizarEstoqueSemRepository(EntradaEstoqueViewModel entradaEstoqueViewModel);
        //EntradaEstoqueViewModel ObterNota(string notaEntradaEstoque);
    }
    public interface ILocalMedicamentoAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(LocalMedicamentoViewModel localMedicamentoViewModel);
        LocalMedicamentoViewModel ObterPorID(Guid id);
        IEnumerable<LocalMedicamentoViewModel> ObterTodos();
        IEnumerable<LocalMedicamentoViewModel> ObterTodosAtivos();
        void Atualizar(LocalMedicamentoViewModel localMedicamentoViewModel);
    }
    public interface IBaixaEstoqueAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(BaixaEstoqueViewModel baixaEstoqueViewModel);
        BaixaEstoqueViewModel ObterPorID(Guid id);
        IEnumerable<BaixaEstoqueViewModel> ObterTodos();
        void Atualizar(BaixaEstoqueViewModel baixaEstoqueViewModel);
    }
    public interface ITipoEntradaEstoqueAppService : IDisposable //Idisposable para poder destruir isto depois
    {
        void Adicionar(TipoEntradaEstoqueViewModel tipoEntradaEstoqueViewModel);
        IEnumerable<TipoEntradaEstoqueViewModel> ObterTodos();
    }
}
