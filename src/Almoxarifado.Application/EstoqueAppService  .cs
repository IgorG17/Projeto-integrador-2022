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
    public class EntradaEstoqueAppService : IEntradaEstoqueAppService
    {
        private readonly EntradaEstoqueRepository _estoqueAppService = new EntradaEstoqueRepository();

        //protected AlmoxarifadoContext Db;

        public void Adicionar(EntradaEstoqueViewModel entradaEstoqueViewModel)
        {
            entradaEstoqueViewModel.dataEntradaEstoque = DateTime.Now;
            var estoque = Mapper.Map<EntradaEstoqueViewModel, EntradaEstoque>(entradaEstoqueViewModel);
            _estoqueAppService.Adicionar(estoque);
        }

        public void Atualizar(EntradaEstoqueViewModel entradaEstoqueViewModel)
        {
            var estoque = Mapper.Map<EntradaEstoqueViewModel, EntradaEstoque>(entradaEstoqueViewModel);
            _estoqueAppService.Atualizar(estoque);
        }
        public void AtualizarEstoqueSemRepository(EntradaEstoqueViewModel entradaEstoqueViewModel)
        {
            var estoque = Mapper.Map<EntradaEstoqueViewModel, EntradaEstoque>(entradaEstoqueViewModel);
            using (var db = new AlmoxarifadoContext())
            {
                //var entry = db.Entry(estoque);
                //var DbSet = db.Set<EntradaEstoque>();
                //db.EntradaEstoque.Attach(estoque);
                //entry.State = EntityState.Modified;
                //db.SaveChanges();
               

                var pesquisaDb = db.EntradaEstoque.First(a => a.idPedido == estoque.idPedido);
                pesquisaDb.quantidadeMedicamentoEstoque = estoque.quantidadeMedicamentoEstoque;
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            _estoqueAppService.Dispose();
            GC.SuppressFinalize(this);
        }

        public EntradaEstoqueViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<EntradaEstoque, EntradaEstoqueViewModel>(_estoqueAppService.ObterPorID(id));
        }

        public IEnumerable<EntradaEstoqueViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<EntradaEstoque>, IEnumerable<EntradaEstoqueViewModel>>(_estoqueAppService.ObterTodos());
        }
        public float ObterCustoMensal(float totalMesAtual)
        {
            var dataAtual = DateTime.Now.ToString();
            var arrayData = dataAtual.Split(' ');
            var DataAtualArray = arrayData[0].Split('/');
            var lista = _estoqueAppService.ObterTodos().Where(x => x.precoPedido > 0).ToList();
            
                
            foreach (var item in lista)
            {
                var dataEntrada = item.dataEntradaEstoque.ToString().Split(' ');
                var DataEntradalArray = dataEntrada[0].Split('/');

                if(DataEntradalArray[1] == DataAtualArray[1])
                {
                    totalMesAtual = +item.precoPedido;
                }               

            }      
            return (totalMesAtual);
        }
        public float ObterCustoAnual(float totalAnoAtual)
        {
            var dataAtual = DateTime.Now.ToString();
            var arrayData = dataAtual.Split(' ');
            var DataAtualArray = arrayData[0].Split('/');
            var lista = _estoqueAppService.ObterTodos().Where(x => x.precoPedido > 0).ToList();


            foreach (var item in lista)
            {
                var dataEntrada = item.dataEntradaEstoque.ToString().Split(' ');
                var DataEntradalArray = dataEntrada[0].Split('/');

                if (DataEntradalArray[2] == DataAtualArray[2])
                {
                    totalAnoAtual = +item.precoPedido;
                }

            }
            return totalAnoAtual;
        }
        public IEnumerable<EntradaEstoqueViewModel> ObterTodosPorNota(string nota)
        {
            return Mapper.Map<IEnumerable<EntradaEstoque>, IEnumerable<EntradaEstoqueViewModel>>(_estoqueAppService.ObterTodosPorNota(nota));
        }

        
    }
    public class LocalMedicamentoAppService : ILocalMedicamentoAppService
    {
        private readonly LocalMedicamentoRepository _localMedicamentoRepository = new LocalMedicamentoRepository();

        public void Adicionar(LocalMedicamentoViewModel localMedicamentoViewModel)
        {

            var local = Mapper.Map<LocalMedicamentoViewModel, LocalMedicamento>(localMedicamentoViewModel);
            _localMedicamentoRepository.Adicionar(local);
        }

        public void Atualizar(LocalMedicamentoViewModel localMedicamentoViewModel)
        {
            var estoque = Mapper.Map<LocalMedicamentoViewModel, LocalMedicamento>(localMedicamentoViewModel);
            _localMedicamentoRepository.Atualizar(estoque);
        }

        public void Dispose()
        {
            _localMedicamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public LocalMedicamentoViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<LocalMedicamento, LocalMedicamentoViewModel>(_localMedicamentoRepository.ObterPorID(id));
        }

        public IEnumerable<LocalMedicamentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<LocalMedicamento>, IEnumerable<LocalMedicamentoViewModel>>(_localMedicamentoRepository.ObterTodos());
        }
        public IEnumerable<LocalMedicamentoViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<LocalMedicamento>, IEnumerable<LocalMedicamentoViewModel>>(_localMedicamentoRepository.ObterTodos().Where(x => x.flAtivo == true));
        }
    }
    public class BaixaEstoqueAppService : IBaixaEstoqueAppService
    {
        private readonly Repository<BaixaEstoque> repository = new Repository<BaixaEstoque>();


        public void Adicionar(BaixaEstoqueViewModel baixaEstoqueViewModel)
        {
            var baixa = Mapper.Map<BaixaEstoqueViewModel, BaixaEstoque>(baixaEstoqueViewModel);
            repository.Adicionar(baixa);
        }

        public void Atualizar(BaixaEstoqueViewModel baixaEstoqueViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public BaixaEstoqueViewModel ObterPorID(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaixaEstoqueViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
    public class TipoEntradaEstoqueAppService : ITipoEntradaEstoqueAppService
    {
        private readonly Repository<TipoEntradaEstoque> repository = new Repository<TipoEntradaEstoque>();
        public void Dispose()
        {
            repository.Dispose();
            GC.SuppressFinalize(this);
        }
        public void Adicionar(TipoEntradaEstoqueViewModel tipoEntradaEstoqueViewModel)
        {

            var entrada = Mapper.Map<TipoEntradaEstoqueViewModel, TipoEntradaEstoque>(tipoEntradaEstoqueViewModel);
            repository.Adicionar(entrada);
        }

        public IEnumerable<TipoEntradaEstoqueViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoEntradaEstoque>, IEnumerable<TipoEntradaEstoqueViewModel>>(repository.ObterTodos());
        }
    }
}
