using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{

    public class Pedido
    {
        public Pedido()
        {
            idPedido = Guid.NewGuid();
        }
        [Key]
        public Guid idPedido { get; set; }
        public int numeroPedido { get; set; }
        public virtual Medicamento medicamentoPedido { get; set; }
        public Guid idMedicamento { get; set; }
        public DateTime dataEntradaPedido { get; set; }
        [Required]
        public string statusPedido { get; set; }
        public DateTime? dataMudancaStatus { get; set; }
        public string motivoPedido { get; set; }
        public int quantidadeMedicamento { get; set; }
        public virtual LocalMedicamento localMedicamento { get; set; }
        public Guid idLocalMedicamento { get; set; }
        //medicoSolicitante
        //responsavelResposta

    }
    //public class StatusPedido
    //{
    //    [Key]
    //    public Guid idStatusPedido { get; set; }
    //    public string nomeStatusPedido { get; set; }
    //}
}