using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{
    public class Medicamento
    {
        public Medicamento()
        {
            idMedicamento = Guid.NewGuid();
        }
        [Key]
        public Guid idMedicamento { get; set; }

        public string nomeMedicamento { get; set; }
        public string nomeQuimicoMedicamento { get; set; }
        public string formaFarmaceuticaMedicamento { get; set; }
        public string bulaMedicamento { get; set; } //GTIN-13
        public string nrMinisterioSaudeMedicamento{ get; set; }
        public string codigoDbcMedicamento { get; set; }
        public bool flativo { get; set; }
        public virtual TipoMedicamento tipoMedicamento { get; set; }
        public Guid idTipoMedicamento { get; set; }
        public virtual CategoriaMedicamento CategoriaMedicamento { get; set; }
        public Guid idCategoriaMedicamento { get; set; }


    }

   



}

