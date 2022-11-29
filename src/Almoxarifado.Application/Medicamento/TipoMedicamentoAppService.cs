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
    public class TipoMedicamentoAppService : ITipoMedicamentoAppService
    {
        private readonly TipoMedicamentoRepository _tipoMedicamentoRepository = new TipoMedicamentoRepository();

        public void Adicionar(TipoMedicamentoViewModel tipoMedicamentoViewModel)
        {
            var tipoMedicamento = Mapper.Map<TipoMedicamentoViewModel, TipoMedicamento>(tipoMedicamentoViewModel);
            _tipoMedicamentoRepository.Adicionar(tipoMedicamento);
        }

        public void Atualizar(TipoMedicamentoViewModel tipoMedicamentoViewModel)
        {
            var tipoMedicamento = Mapper.Map<TipoMedicamentoViewModel, TipoMedicamento>(tipoMedicamentoViewModel);
            _tipoMedicamentoRepository.Atualizar(tipoMedicamento);
        }

        public void Dispose()
        {
            _tipoMedicamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public TipoMedicamentoViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<TipoMedicamento, TipoMedicamentoViewModel>(_tipoMedicamentoRepository.ObterPorID(id));
        }

        public IEnumerable<TipoMedicamentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<TipoMedicamento>, IEnumerable<TipoMedicamentoViewModel>>(_tipoMedicamentoRepository.ObterTodos());
        }
        public IEnumerable<TipoMedicamentoViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<TipoMedicamento>, IEnumerable<TipoMedicamentoViewModel>>(_tipoMedicamentoRepository.ObterTodos().Where(x => x.flAtivo == true));
        }
    }
}
