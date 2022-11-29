using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            idUsuario = Guid.NewGuid();
        }
        [Key]
        public Guid idUsuario { get; set; }

        public string nomeUsuario { get; set; }
        public string loginUsuario { get; set; }
        public string senhaUsuario { get; set; }
        public bool flAtivo { get; set; }
        public virtual Role role { get; set; }
        public Guid? idRole { get; set; }
    }
    public class Role
    {
        [Key]
        public Guid idRole { get; set; }
        public string nomeRole { get; set; }
    }
}


