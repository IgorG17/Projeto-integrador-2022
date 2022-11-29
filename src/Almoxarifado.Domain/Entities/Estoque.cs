using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{

    public class EntradaEstoque
    {
        public EntradaEstoque()
        {
            idEntradaEstoque = Guid.NewGuid();
        }
        [Key]
        public Guid idEntradaEstoque { get; set; }
        public string notaEntradaEstoque { get; set; }
        public DateTime? dataEntradaEstoque { get; set; }

        public virtual Medicamento medicamentoEstoque { get; set; }
        public Guid idMedicamento { get; set; }

        public virtual TipoEntradaEstoque TipoEntradaEstoque { get; set; }
        public Guid idTipoEntradaEstoque { get; set; }

        public string loteMedicamentoEstoque { get; set; }
        public int quantidadeMedicamentoEstoque { get; set; }
        public DateTime validadeMedicamento { get; set; }
        public virtual LocalMedicamento localMedicamento { get; set; }
        public Guid idLocalMedicamento { get; set; }
        public virtual Pedido pedido { get; set; }
        public Guid? idPedido { get; set; }
        public float precoPedido { get; set; }
        public int? transportadoraPedido { get; set; }
        //quantidade minima de estoque para medicamento
        //quantidade máxima de estoque para medicamento

    }
    public class TipoEntradaEstoque
    {
        [Key]
        public Guid idTipoEntradaEstoque { get; set; }
        public string nomeTipoEntradaEstoque { get; set; }

    }

    public class LocalMedicamento
    {
        public LocalMedicamento()
        {
            idLocalMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idLocalMedicamento { get; set; }
        public string nomeLocalMedicamento { get; set; }
        //public string subLocalMedicamento { get; set; }
        public bool flAtivo{ get; set; }
        //public List<EstoqueMinimoLocal> estoqueMinimo { get; set; }

    }
    //public class EstoqueMinimoLocal
    //{
    //    public EstoqueMinimoLocal()
    //    {
    //        idEstoqueMinimoLocal = Guid.NewGuid();
    //    }
    //    [Key]
    //    public Guid idEstoqueMinimoLocal { get; set; }
    //    public Medicamento Medicamento { get; set; }
    //    public int quantidadeEstoqueMinimoLocal { get; set; }
    //}
    public class StatusMedicamento
    {
        [Key]
        public Guid idStatusMedicamento { get; set; }
        public string nomeStatusMedicamento { get; set; }

    }

    public class BaixaEstoque
    {
        public BaixaEstoque()
        {
            idBaixaEstoque = Guid.NewGuid();
        }
        [Key]
        public Guid idBaixaEstoque { get; set; }
        public virtual EntradaEstoque entradaEstoque { get; set; }
        public Guid idEntradaEstoque { get; set; }
        public DateTime dataBaixaEstoque { get; set; }
        public string nomePacienteBaixaEstoque { get; set; }
        public string documentoPacienteBaixaEstoque { get; set; }
        public string numeroCaixaBaixaEstoque{ get; set; }
        public string pacienteBaixaEstoque { get; set; }
    }
}

//public class PacienteBaixaEstoque
//{
//    public PacienteBaixaEstoque()
//    {
//        idPacienteBaixaEstoque = Guid.NewGuid();
//    }
//    [Key]
//    public Guid idPacienteBaixaEstoque { get; set; }
//    public string nomePacienteBaixaEstoque { get; set; }
//    public string documentoPacienteBaixaEstoque { get; set; }
//}



//public class SaidaEstoque
//{
//    public SaidaEstoque()
//    {
//        idSaidaEstoque = Guid.NewGuid();
//    }
//    [Key]
//    public Guid idSaidaEstoque { get; set; }
//    public DateTime dataSaidaEstoque { get; set; }

//    public virtual Medicamento medicamentoEStoque { get; set; }
//    public Guid idMedicamento { get; set; }

//    public string loteMedicamentoEstoque { get; set; }
//    public float quantidadeMedicamentoEstoque { get; set; }
//    public float quantidadeMedicamentoBaixaEstoque { get; set; }
//    public DateTime validadeMedicamento { get; set; }
//    public string localMedicamento { get; set; }

//    public virtual CategoriaMedicamento categoriaMedicamentoEstoque { get; set; }
//    public Guid idCategoriaMedicamento { get; set; }

//    public virtual TipoMedicamento tipoMedicamentoEstoque { get; set; }
//    public Guid idTipoMedicamento { get; set; }
//}






