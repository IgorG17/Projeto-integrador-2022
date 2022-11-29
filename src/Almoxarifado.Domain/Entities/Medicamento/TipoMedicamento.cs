using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{
    public class TipoMedicamento
    {
        public TipoMedicamento()
        {
            idTipoMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idTipoMedicamento { get; set; }

        public string nomeTipoMedicamento { get; set; }

        public bool flAtivo { get; set; }
    }



}


