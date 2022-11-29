using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Almoxarifado.Application.ViewModels;
using Almoxarifado.Domain.Entities;


namespace Almoxarifado.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile // Profile é uma classe interna do AutoMapper
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<Medicamento, MedicamentoViewModel>(); //Converto os dados de cliente para ClienteViewModel            
            Mapper.CreateMap<CategoriaMedicamento, CategoriaMedicamentoViewModel>();
            Mapper.CreateMap<TipoMedicamento, TipoMedicamentoViewModel>();
            Mapper.CreateMap<EntradaEstoque, EntradaEstoqueViewModel>();
            Mapper.CreateMap<LocalMedicamento, LocalMedicamentoViewModel>();
            Mapper.CreateMap<BaixaEstoque, BaixaEstoqueViewModel>();
            Mapper.CreateMap<TipoEntradaEstoque, TipoEntradaEstoqueViewModel>();
            Mapper.CreateMap<Pedido, PedidoViewModel>();
            Mapper.CreateMap<Usuario, UsuarioViewModel>();
            Mapper.CreateMap<Role, RoleViewModel>();
            //Mapper.CreateMap<StatusPedido, StatusPedidoViewModel>();
        }
    }
}

