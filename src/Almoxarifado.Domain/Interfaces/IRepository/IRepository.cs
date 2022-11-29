using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Domain.Interfaces.IRepository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class //T é Generics
    {
        void Adicionar(TEntity obj); // Adicionar uma entidade genérica
        TEntity ObterPorID(Guid id); // Retornar a entidade através do método ObterPorID
        IEnumerable<TEntity> ObterTodos(); // Retornar uma lista de entidades
        void Atualizar(TEntity obj); // Método de atualização da entidade
        void Remover(Guid id); // Método de remoção através do ID. Desconsiderar, será feito DESATIVAÇÃO
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate); //Método de busca genérica
        int SaveChanges();
    }
}
