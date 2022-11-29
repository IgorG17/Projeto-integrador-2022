using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{
    public class CategoriaMedicamento
    {
        public CategoriaMedicamento()
        {
            idCategoriaMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idCategoriaMedicamento { get; set; }

        public string nomeCategoriaMedicamento { get; set; }

        public bool flAtivo { get; set; }
    }



}

