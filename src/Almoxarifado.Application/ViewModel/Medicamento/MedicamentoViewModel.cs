using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Almoxarifado.Application.ViewModels
{
    public class MedicamentoViewModel
    {
        public MedicamentoViewModel()
        {
            idMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idMedicamento { get; set; }
        [Required(ErrorMessage = "Preencha o Nome do Medicamento")]
        [MaxLength(60, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome Popular do Medicamento")]
        public string nomeMedicamento { get; set; }
        public string formaFarmaceuticaMedicamento { get; set; }

        [Required(ErrorMessage = "Preencha o Nome do Medicamento")]
        [MaxLength(60, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome Quimico do Medicamento")]
        public string nomeQuimicoMedicamento { get; set; }
        public string bulaMedicamento { get; set; }
        public string nrMinisterioSaudeMedicamento { get; set; }
        public string codigoDbcMedicamento { get; set; }

        public virtual CategoriaMedicamento CategoriaMedicamento { get; set; }
        public virtual TipoMedicamento tipoMedicamento { get; set; }
        public bool flativo { get; set; }
        public Guid idCategoriaMedicamento { get; set; }
        [Required]
        public Guid idTipoMedicamento { get; set; }
    }
}
