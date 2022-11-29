using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Domain.Interfaces.IRepository;
using Almoxarifado.Infra.Data.Repository;
using Dapper;
using Almoxarifado.Infra.Data;
using System;
using System.Data.Entity;
using Almoxarifado.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
//using Almoxarifado.Infra.Data.Entity_Config;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Infra.Data.Repository
{
   
    public class EntradaEstoqueRepository : Repository<EntradaEstoque>, IEntradaRepository
    {
        public virtual IEnumerable<EntradaEstoque> ObterTodosPorNota(string nota)
        {
          
        EntradaEstoque entradaEstoque = new EntradaEstoque();
        List<String> listaObjetos = new List<String>();
        var con = "";
    
            using (SqlConnection connection = new SqlConnection()) // ta dando erro aqui. Connectionstring https://stackoverflow.com/questions/12024226/how-to-generate-liststring-from-sql-query
            {
                connection.Open();
                string query = "Select * from EntradaEstoque where notaEntradaEstoque = '" + nota + "'";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaObjetos.Add(reader.GetString(0));
                        }
                    }
                }
                return (IEnumerable<EntradaEstoque>)listaObjetos;
            }
        }
    }
    public class LocalMedicamentoRepository : Repository<LocalMedicamento>, ILocalMedicamentoRepository
{

    public LocalMedicamento ObterPorNomeLocal(string nomeLocalMedicamento)
    {
        return DbSet.FirstOrDefault(c => c.nomeLocalMedicamento == nomeLocalMedicamento);
    }

}
}
