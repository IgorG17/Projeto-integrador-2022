using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Application.ViewModels
{

    public class UsuarioViewModel
    {
        //public UsuarioViewModel()
        //{
        //    idUsuario = Guid.NewGuid();
        //}
        [Key]
        public Guid idUsuario { get; set; }

        public string nomeUsuario { get; set; }
        [DisplayName("Login")]
        public string loginUsuario { get; set; }
        [DisplayName("Senha")]
        public string senhaUsuario { get; set; }
        public bool flAtivo { get; set; }
        public bool lembrarMe { get; set; }
        public virtual RoleViewModel role { get; set; }
        public Guid? idRole { get; set; }
    }
    public class RoleViewModel
    {
        [Key]
        public Guid idRole { get; set; }
        public string nomeRole { get; set; }
    }
}