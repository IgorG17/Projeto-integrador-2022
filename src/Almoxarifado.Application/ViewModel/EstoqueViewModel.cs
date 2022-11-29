using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Almoxarifado.Application.ViewModels
{
    public class EntradaEstoqueViewModel
    {
        public EntradaEstoqueViewModel()
        {
            idEntradaEstoque = Guid.NewGuid();
        }
        [Key]
        public Guid idEntradaEstoque { get; set; }
        public string notaEntradaEstoque { get; set; }
        public DateTime? dataEntradaEstoque { get; set; }
        public virtual Medicamento medicamentoEstoque { get; set; }
        public virtual LocalMedicamento localMedicamento { get; set; }
        public Guid idMedicamento { get; set; }
        public string loteMedicamentoEstoque { get; set; }
        public int quantidadeMedicamentoEstoque { get; set; }
        public Guid idTipoEntradaEstoque { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime validadeMedicamento { get; set; }
        public Guid idLocalMedicamento { get; set; }
        public float precoPedido { get; set; }
        public virtual BaixaEstoque baixaEstoque { get; set; }
    }
    public class TipoEntradaEstoqueViewModel
    {
        [Key]
        public Guid idTipoEntradaEstoque { get; set; }
        public string nomeTipoEntradaEstoque { get; set; }

    }

    public class LocalMedicamentoViewModel
    {
        public LocalMedicamentoViewModel()
        {
            idLocalMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idLocalMedicamento { get; set; }
        public string nomeLocalMedicamento { get; set; }
        //public string subLocalMedicamento { get; set; }
        public bool flAtivo { get; set; }
    }
    public class BaixaEstoqueViewModel
    {
        public BaixaEstoqueViewModel()
        {
            idEntradaEstoque = Guid.NewGuid();
        }
        [Key]
        public Guid idEntradaEstoque { get; set; }
        public string notaEntradaEstoque { get; set; }
        public DateTime? dataEntradaEstoque { get; set; }
        public string loteMedicamentoEstoque { get; set; }
        public int quantidadeMedicamentoEstoque { get; set; }
        public int quantidadeBaixa { get; set; }
        public DateTime validadeMedicamento { get; set; }
        public string nomeMedicamentoBaixa { get; set; }
        public string nomeLocalBaixa { get; set; }
        public Guid idMedicamento { get; set; }
        public Guid idLocalMedicamento { get; set; }
        public string nomePacienteBaixaEstoque { get; set; }
        public string documentoPacienteBaixaEstoque { get; set; }
        public DateTime dataBaixaEstoque { get; set; }
        public Guid idPedido { get; set; }

        //public Guid idUsuario { get; set; } //Criar repository para SELECIONAR o usuário
        //public Guid idStatusMedicamento { get; set; }
    }
}

