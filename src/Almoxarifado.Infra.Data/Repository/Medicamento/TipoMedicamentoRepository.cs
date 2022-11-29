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
    public class TipoMedicamentoRepository : Repository<TipoMedicamento>, ITipoMedicamentoRepository
    {

        public TipoMedicamento ObterPorNomeTipoMedicamento(string nomeTipoMedicamento) 
        {
            return DbSet.FirstOrDefault(c => c.nomeTipoMedicamento == nomeTipoMedicamento);
        } 


    }
}
