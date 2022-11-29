using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Interfaces.IRepository;
using Almoxarifado.Infra.Data.Repository;
using Dapper;

namespace Almoxarifado.Infra.Data.Repository
{
    public class MedicamentoRepository : Repository<Medicamento>, IMedicamentoRepository
    {

        public Medicamento ObterPorNomeMedicamento(string nomeMedicamento) 
        {
            return DbSet.FirstOrDefault(c => c.nomeMedicamento == nomeMedicamento);
        } //Verificar se é melhor usar DbSet ou método Buscar de Repository
        //public Medicamento ObterPorTipoMedicamento(string idTipoMedicamento)
        //{
        //    return DbSet.FirstOrDefault(c => c.idTipoMedicamento == idTipoMedicamento);
        //} //Verificar se é melhor usar DbSet ou método Buscar de Repository
        //public Medicamento ObterPorCategoriaMedicamento(string categoriaMedicamento)
        //{
        //    return DbSet.FirstOrDefault(c => c.cate == categoriaMedicamento);
        //} //Verificar se é melhor usar DbSet ou método Buscar de Repository


    }
}
