using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Almoxarifado.Domain.Interfaces.IRepository;
using Almoxarifado.Infra.Data;

namespace Almoxarifado.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class // O último TEntity é do tipo classe, porém o que está sendo publicado nao
    {
        protected AlmoxarifadoContext Db; //Db é uma variavel que vem de context
        protected DbSet<TEntity> DbSet;
        public Repository()
        {
            Db = new AlmoxarifadoContext(); // Cria uma instancia
            DbSet = Db.Set<TEntity>();
        }
        public virtual void Adicionar(TEntity obj)
        {
            DbSet.Add(obj);
            Db.SaveChanges();
        }

        public virtual void Atualizar(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate); //Predicate é uma expressão lambda que faz buscas genéricas
        }

        public virtual void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this); // Utiliza Gargbage collector para acabar o mais rápido possível com o db  
        }

        public virtual TEntity ObterPorID(Guid id)
        {
            return DbSet.Find(id);
        }


        public virtual TEntity ObterPorNome(string nome)
        {
            return DbSet.Find(nome);
        }
        public virtual IEnumerable<TEntity> ObterTodos() //Importante paginar aqui
        {
            return DbSet.ToList();
        }

        public virtual void Remover(Guid id)
        {
            DbSet.Remove(ObterPorID(id));
            Db.SaveChanges();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}