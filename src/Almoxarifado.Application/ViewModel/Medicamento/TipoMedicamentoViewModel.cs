using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Almoxarifado.Application.ViewModels
{
    public class TipoMedicamentoViewModel
    {
        public TipoMedicamentoViewModel()
        {
            idTipoMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idTipoMedicamento { get; set; }
        [Required(ErrorMessage = "Preencha o Nome do Tipo do Medicamento")]
        [MaxLength(60, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Tipo do Medicamento")]
        public string nomeTipoMedicamento { get; set; }
        
        public bool flAtivo { get; set; }        



    }
}
