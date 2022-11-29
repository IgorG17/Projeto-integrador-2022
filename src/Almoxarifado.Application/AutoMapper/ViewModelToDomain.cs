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
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return " ViewModelToDomainMappings"; }
        }
        protected override void Configure()
        {
            Mapper.CreateMap<MedicamentoViewModel, Medicamento>();
            Mapper.CreateMap<CategoriaMedicamentoViewModel, CategoriaMedicamento>();
            Mapper.CreateMap<TipoMedicamentoViewModel, TipoMedicamento>();
            Mapper.CreateMap<EntradaEstoqueViewModel, EntradaEstoque>();
            Mapper.CreateMap<LocalMedicamentoViewModel, LocalMedicamento>();
            Mapper.CreateMap<BaixaEstoqueViewModel, BaixaEstoque>();
            Mapper.CreateMap<TipoEntradaEstoqueViewModel, TipoEntradaEstoque>();
            Mapper.CreateMap<PedidoViewModel, Pedido>();
            Mapper.CreateMap<UsuarioViewModel, Usuario>();
            Mapper.CreateMap<RoleViewModel, Role>();
            //Mapper.CreateMap<StatusPedidoViewModel, StatusPedido>();
        }
    }
}

