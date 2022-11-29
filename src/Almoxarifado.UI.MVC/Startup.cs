using Microsoft.Owin;
using Owin;
using Almoxarifado.Application;
using Almoxarifado.Application.ViewModels;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(Almoxarifado.UI.MVC.Startup))]
namespace Almoxarifado.UI.MVC
{
    public partial class Startup
    {
        private UsuarioAppService _usuarioAppService = new UsuarioAppService();
        private RoleAppService _roleAppService = new RoleAppService();
        private TipoEntradaEstoqueAppService _tipoEntradaEstoqueAppService = new TipoEntradaEstoqueAppService();
        private LocalMedicamentoAppService _localMedicamentoAppService = new LocalMedicamentoAppService();
        private MedicamentoAppService _medicamentoAppService = new MedicamentoAppService();
        private TipoMedicamentoAppService _tipoMedicamentoAppService = new TipoMedicamentoAppService();
        private CategoriaMedicamentoAppService _categoriaMedicamentoAppService_ = new CategoriaMedicamentoAppService();
        public void Configuration(IAppBuilder app)
        {
            #region CriarPermissao                        
            if (_roleAppService.ObterTodos().Count() == 0 )
            {
                RoleViewModel roleViewModel = new RoleViewModel();
                roleViewModel.nomeRole = "Administrador";
                roleViewModel.idRole = new System.Guid("cdef7890-abcd-1234-abcd-1234567890ab");
                _roleAppService.Adicionar(roleViewModel);
                roleViewModel.nomeRole = "Medico";
                roleViewModel.idRole = new System.Guid("cdef7890-abcd-1334-abcd-1234567890ab");
                _roleAppService.Adicionar(roleViewModel);

            }
            #endregion
            #region CriarUsuarioAdmin  
            if (_usuarioAppService.ObterTodos().Count() == 0)
            {
                UsuarioViewModel usuario = new UsuarioViewModel();
                usuario.nomeUsuario = "Administrador";
                usuario.senhaUsuario = "123";
                usuario.loginUsuario = "admin";
                usuario.idRole = new System.Guid("CDEF7890-ABCD-1234-ABCD-1234567890AB");                
                _usuarioAppService.Adicionar(usuario);
            }
            #endregion
            #region CriarTipoEntrada
            if(_tipoEntradaEstoqueAppService.ObterTodos().Count() == 0)
            {
                TipoEntradaEstoqueViewModel tipoEntradaEstoqueViewModel = new TipoEntradaEstoqueViewModel();
                tipoEntradaEstoqueViewModel.idTipoEntradaEstoque = new System.Guid("CDEF7890-ABCD-0000-ABCD-1234567890AB");
                tipoEntradaEstoqueViewModel.nomeTipoEntradaEstoque = "Compra";
                _tipoEntradaEstoqueAppService.Adicionar(tipoEntradaEstoqueViewModel);
                tipoEntradaEstoqueViewModel.idTipoEntradaEstoque = new System.Guid("CDEF7890-ABCD-1111-ABCD-1234567890AB");
                tipoEntradaEstoqueViewModel.nomeTipoEntradaEstoque = "Pedido";
                _tipoEntradaEstoqueAppService.Adicionar(tipoEntradaEstoqueViewModel);
                tipoEntradaEstoqueViewModel.idTipoEntradaEstoque = new System.Guid("CDEF7890-ABCD-2222-ABCD-1234567890AB");
                tipoEntradaEstoqueViewModel.nomeTipoEntradaEstoque = "Correção";
                _tipoEntradaEstoqueAppService.Adicionar(tipoEntradaEstoqueViewModel);
                tipoEntradaEstoqueViewModel.idTipoEntradaEstoque = new System.Guid("CDEF7890-ABCD-3333-ABCD-1234567890AB");
                tipoEntradaEstoqueViewModel.nomeTipoEntradaEstoque = "Doação";
                _tipoEntradaEstoqueAppService.Adicionar(tipoEntradaEstoqueViewModel);
            }


            #endregion
            #region CriarLocal
            if(_localMedicamentoAppService.ObterTodos().Count() == 0)
            {
                LocalMedicamentoViewModel localMedicamentoViewModel = new LocalMedicamentoViewModel();
                localMedicamentoViewModel.idLocalMedicamento = new System.Guid("ABCF7890-ABCD-1234-ABCD-1234567890AB");
                localMedicamentoViewModel.nomeLocalMedicamento = "Estoque Central";
                localMedicamentoViewModel.flAtivo = true;
                //localMedicamentoViewModel.subLocalMedicamento = "Setor A";
                _localMedicamentoAppService.Adicionar(localMedicamentoViewModel);
            }
            #endregion
            #region CriarTipoMedicamento
            if (_tipoMedicamentoAppService.ObterTodos().Count() == 0)
            {
                TipoMedicamentoViewModel tipoMedicamentoViewModel = new TipoMedicamentoViewModel();
                tipoMedicamentoViewModel.idTipoMedicamento = new System.Guid("ACCF7890-ABCD-1234-ABCD-1234567890AB");
                tipoMedicamentoViewModel.nomeTipoMedicamento = "Comprimido";
                tipoMedicamentoViewModel.flAtivo = true;              
                _tipoMedicamentoAppService.Adicionar(tipoMedicamentoViewModel);
            }
            #endregion
            #region CriarCategoriaMedicamento
            if (_categoriaMedicamentoAppService_.ObterTodos().Count() == 0)
            {
                CategoriaMedicamentoViewModel _categoriaMedicamentoViewModel = new CategoriaMedicamentoViewModel();
                _categoriaMedicamentoViewModel.idCategoriaMedicamento = new System.Guid("ACAF7890-ABCD-1234-ABCD-1234567890AB");
                _categoriaMedicamentoViewModel.nomeCategoriaMedicamento = "Controlado";
                _categoriaMedicamentoViewModel.flativo = true;
                _categoriaMedicamentoAppService_.Adicionar(_categoriaMedicamentoViewModel);
            }
            #endregion
            #region CriarMedicamento
            if (_medicamentoAppService.ObterTodos().Count() == 0 && _tipoMedicamentoAppService.ObterTodos().Count() > 0 && _categoriaMedicamentoAppService_.ObterTodos().Count() > 0)
            {
                MedicamentoViewModel medicamentoViewModel = new MedicamentoViewModel();
                medicamentoViewModel.bulaMedicamento = "Rivotril® também é indicado para: Transtornos de ansiedade, como ansiolítico em geral(...)";
                medicamentoViewModel.codigoDbcMedicamento = "02300";
                medicamentoViewModel.flativo = true;
                medicamentoViewModel.formaFarmaceuticaMedicamento = "Solução oral de 2,5 mg/mL. Frasco com 20 mL. Excipientes: sacarina sódica, ácido acético, propilenoglicol, essência de pêssego. Cada 1 mL de Rivotril® solução oral equivale a cerca de 25 gotas.";
                medicamentoViewModel.idCategoriaMedicamento = new System.Guid("ACAF7890-ABCD-1234-ABCD-1234567890AB");
                medicamentoViewModel.idTipoMedicamento = new System.Guid("ACCF7890-ABCD-1234-ABCD-1234567890AB");
                medicamentoViewModel.idMedicamento = new System.Guid("ABCF7890-DDFF-1234-ABCD-1234567890AB");
                medicamentoViewModel.nomeMedicamento = "Rivotril";
                medicamentoViewModel.nomeQuimicoMedicamento = "Clonazepam";
                medicamentoViewModel.nrMinisterioSaudeMedicamento = "1152400110061";
                _medicamentoAppService.Adicionar(medicamentoViewModel);
            }
            #endregion


            ConfigureAuth(app);
        }
    }
}
