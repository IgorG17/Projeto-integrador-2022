using Almoxarifado.Application.Interface;
using Almoxarifado.Application.ViewModels;
using Almoxarifado.Domain.Entities;
using Almoxarifado.Infra.Data;
using System;
using System.Collections.Generic;
using AutoMapper;
using Almoxarifado.Infra.Data.Repository;
using System.Data.Entity;
using System.Linq;

namespace Almoxarifado.Application
{
    public class UsuarioAppService : IUsuarioAppService
    {
        protected AlmoxarifadoContext Db = new AlmoxarifadoContext();
        private readonly Repository<Usuario> _usuarioRepository = new Repository<Usuario>();

        //protected AlmoxarifadoContext Db;

        public void Adicionar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            _usuarioRepository.Adicionar(usuario);

        }

        public void Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(usuarioViewModel);
            _usuarioRepository.Atualizar(usuario);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }


        public UsuarioViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioRepository.ObterPorID(id));
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarioRepository.ObterTodos());
        }

        public UsuarioViewModel ObterPorNome(string nome)
        {
            return Mapper.Map<Usuario, UsuarioViewModel>(_usuarioRepository.ObterPorNome(nome));
        }

        public UsuarioViewModel ValidarUsuario(UsuarioViewModel usuarioViewModel)
        {

            var usuarioIsOk = Db.Usuarios.Where(x => x.loginUsuario == usuarioViewModel.loginUsuario && x.senhaUsuario == usuarioViewModel.senhaUsuario).FirstOrDefault();


            if (usuarioIsOk != null)
            {
                return Mapper.Map<Usuario, UsuarioViewModel>(usuarioIsOk);
            }
            else
            {
                return null;
            }

        }


    }
    public class RoleAppService : IRoleAppService
    {
        private readonly Repository<Role> _roleRepository = new Repository<Role>();
        public void Dispose()
        {
            _roleRepository.Dispose();
            GC.SuppressFinalize(this);
        }
        public void Adicionar(RoleViewModel roleViewModel)
        {
            var role = Mapper.Map<RoleViewModel, Role>(roleViewModel);
            _roleRepository.Adicionar(role);
        }
        public RoleViewModel ObterPorID(Guid id)
        {
            return Mapper.Map<Role, RoleViewModel>(_roleRepository.ObterPorID(id));
        }

        public IEnumerable<RoleViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(_roleRepository.ObterTodos());
        }
    }

}
