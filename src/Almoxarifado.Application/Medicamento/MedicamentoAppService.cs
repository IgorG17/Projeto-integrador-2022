using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Infra.Data;
using System;
using System.Collections.Generic;
using Almoxarifado.Infra.Data.Repository;
using Almoxarifado.Application.ViewModels;
using AutoMapper;
using Almoxarifado.Infra.Data.Repository;
using System.Linq;

namespace Almoxarifado.Application
{
    public class MedicamentoAppService : IMedicamentoAppService
    {

        private readonly MedicamentoRepository _medicamentoRepository = new MedicamentoRepository();
        
        public void Adicionar(MedicamentoViewModel medicamentoViewModel)
        {
            var medicamento = Mapper.Map<MedicamentoViewModel, Medicamento>(medicamentoViewModel);
            _medicamentoRepository.Adicionar(medicamento);
        }

        public void Atualizar(MedicamentoViewModel medicamentoViewModel)
        {
            var medicamento = Mapper.Map<MedicamentoViewModel, Medicamento>(medicamentoViewModel);
            _medicamentoRepository.Atualizar(medicamento);
        }

        public void Dispose()
        {
            _medicamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public MedicamentoViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<Medicamento, MedicamentoViewModel>(_medicamentoRepository.ObterPorID(id));
        }

        public MedicamentoViewModel ObterPorNomeMedicamento(string nomeMedicamento)
        {
            return Mapper.Map<Medicamento, MedicamentoViewModel>(_medicamentoRepository.ObterPorNomeMedicamento(nomeMedicamento));
        }

        public IEnumerable<MedicamentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Medicamento>, IEnumerable<MedicamentoViewModel>>(_medicamentoRepository.ObterTodos());
        }
        public IEnumerable<MedicamentoViewModel> ObterTodosAtivos()
        {
            return Mapper.Map<IEnumerable<Medicamento>, IEnumerable<MedicamentoViewModel>>(_medicamentoRepository.ObterTodos().Where(x => x.flativo == true));
        }

        public void Remover(Guid id)
        {
            _medicamentoRepository.Remover(id);
        }
    }
}
