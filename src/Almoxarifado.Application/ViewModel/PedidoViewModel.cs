using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Application.ViewModels
{

    public class PedidoViewModel
    {
        public PedidoViewModel()
        {
            idPedido = Guid.NewGuid();
        }
        [Key]
        public Guid idPedido { get; set; }
        public int numeroPedido { get; set; }
        [Required]
        public Guid idMedicamento { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? dataEntradaPedido { get; set; }
        //public Guid? idStatusPedido { get; set; }
        public string statusPedido { get; set; }
        public DateTime? dataMudancaStatus { get; set; }
        [Required]
        public string motivoPedido { get; set; }
        [Required]
        public int quantidadeMedicamento { get; set; }
        [Required]
        public Guid idLocalMedicamento { get; set; }
        public virtual Medicamento medicamentoPedido { get; set; }
    }

    //public class StatusPedidoViewModel
    //{
    //    [Key]
    //    public Guid idStatusPedido { get; set; }
    //    public string nomeStatusPedido { get; set; }
    //}
}