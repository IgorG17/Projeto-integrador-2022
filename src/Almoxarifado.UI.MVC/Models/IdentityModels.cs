using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Almoxarifado.UI.MVC.Models
{
    // É possível adicionar dados do perfil do usuário adicionando mais propriedades na sua classe ApplicationUser, visite https://go.microsoft.com/fwlink/?LinkID=317594 para obter mais informações.
    public class ApplicationUser : IdentityUser
    {
        //public string nomeUsuario { get; set; }
        //public Guid idUsuario { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
           
            // Observe que a authenticationType deve corresponder a uma definida em CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //userIdentity.AddClaim(new Claim(idUsuario, this.idUsuario));
            // Adicionar declarações do usuário personalizadas aqui
            return userIdentity;
        }
    }
    //public static class IdentityHelper
    //{
    //    public static string GetUsuarioNome(this IIdentity identity)
    //    {
    //        var claimIdent = identity as ClaimsIdentity;
    //        return claimIdent != null
    //            && claimIdent.HasClaim(c => c.Type == "idUsuario")
    //            ? claimIdent.FindFirst("idUsuario").Value
    //            : string.Empty;
    //    }
    //}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.MedicamentoViewModel> MedicamentoViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.CategoriaMedicamentoViewModel> CategoriaMedicamentoViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.TipoMedicamentoViewModel> TipoMedicamentoViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.EntradaEstoqueViewModel> EntradaEstoqueViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.LocalMedicamentoViewModel> LocalMedicamentoViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.PedidoViewModel> PedidoViewModels { get; set; }

        public System.Data.Entity.DbSet<Almoxarifado.Application.ViewModels.UsuarioViewModel> UsuarioViewModels { get; set; }
    }
}