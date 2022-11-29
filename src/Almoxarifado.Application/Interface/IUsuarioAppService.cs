using Almoxarifado.Domain.Entities;
using System;
using System.Collections.Generic;
using Almoxarifado.Application.ViewModels;


namespace Almoxarifado.Application.Interface
{
    public interface IUsuarioAppService: IDisposable 
    {
        void Adicionar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ObterPorID(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        void Atualizar(UsuarioViewModel usuarioViewModel);
        UsuarioViewModel ValidarUsuario(UsuarioViewModel usuarioViewModel);        
    }
    public interface IRoleAppService : IDisposable
    {        
        RoleViewModel ObterPorID(Guid id);
        IEnumerable<RoleViewModel> ObterTodos();   
    }
}
