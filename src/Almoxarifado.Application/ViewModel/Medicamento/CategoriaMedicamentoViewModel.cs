using Almoxarifado.Application.Interface;
using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Almoxarifado.Application.ViewModels
{
    public class CategoriaMedicamentoViewModel
    {
        public CategoriaMedicamentoViewModel()
        {
            idCategoriaMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idCategoriaMedicamento { get; set; }
        [Required(ErrorMessage = "Preencha o Nome da Categoria do Medicamento")]
        [MaxLength(60, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Categoria do Medicamento")]
        public string nomeCategoriaMedicamento { get; set; }        
        public bool flativo { get; set; }        

    }
}
