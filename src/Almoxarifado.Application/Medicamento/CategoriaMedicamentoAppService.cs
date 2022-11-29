using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Infra.Data;
using System;
using System.Collections.Generic;
using Almoxarifado.Infra.Data.Repository;
using Almoxarifado.Application.ViewModels;
using AutoMapper;
using System.Linq;

namespace Almoxarifado.Application
{
    public class CategoriaMedicamentoAppService : ICategoriaMedicamentoAppService
    {
        private readonly CategoriaMedicamentoRepository _categoriaMedicamentoRepository = new CategoriaMedicamentoRepository();
        

        public void Adicionar(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel)
        {
            var categoriaMedicamento = Mapper.Map<CategoriaMedicamentoViewModel, CategoriaMedicamento>(categoriaMedicamentoViewModel);
            _categoriaMedicamentoRepository.Adicionar(categoriaMedicamento);
        }

        public void Atualizar(CategoriaMedicamentoViewModel categoriaMedicamentoViewModel)
        {
            var categoriaMedicamento = Mapper.Map<CategoriaMedicamentoViewModel, CategoriaMedicamento>(categoriaMedicamentoViewModel);
            _categoriaMedicamentoRepository.Atualizar(categoriaMedicamento);
        }

        public void Dispose()
        {
            _categoriaMedicamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public CategoriaMedicamentoViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<CategoriaMedicamento, CategoriaMedicamentoViewModel>(_categoriaMedicamentoRepository.ObterPorID(id));
        }


        public IEnumerable<CategoriaMedicamentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<CategoriaMedicamento>, IEnumerable<CategoriaMedicamentoViewModel>>(_categoriaMedicamentoRepository.ObterTodos());
        }

        public IEnumerable<CategoriaMedicamentoViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<CategoriaMedicamento>, IEnumerable<CategoriaMedicamentoViewModel>>(_categoriaMedicamentoRepository.ObterTodos().Where(x => x.flAtivo == true));
        }
    }
}
