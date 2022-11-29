using System;
using System.Data.Entity;
using Almoxarifado.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
//using Almoxarifado.Infra.Data.Entity_Config;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almoxarifado.Infra.Data
{
    public class AlmoxarifadoContext : DbContext
    {
        public AlmoxarifadoContext() : base("AlmoxarifadoConnectionString") { }
      

        public DbSet<Medicamento> Medicamentos { get; set; }

        public DbSet<TipoMedicamento> TipoMedicamentos { get; set; }
        public DbSet<CategoriaMedicamento> CategoriaMedicamentos { get; set; }
        public DbSet<EntradaEstoque> EntradaEstoque { get; set; }
        public DbSet<LocalMedicamento> LocalMedicamento { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<BaixaEstoque> BaixaEstoque{ get; set; }
        public DbSet<TipoEntradaEstoque> TipoEntradaEstoques { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<StatusMedicamento> StatusMedicamento { get; set; }
        //public DbSet<StatusPedido> StatusPedido { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //Remove a pluralização autómática das tabelas
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //Remove a possibilidade de ao remover uma informação, todos seus dados serem removidos.
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>(); //Remove a possibilidade de ao remover um informação, todos seus dados serem removidos.
        
            //o pedro passou por aq

            modelBuilder.Properties() // Caso um objeto possuir "ID" no nome, o mesmo será automaticamente denominado como primary key
                .Where(p => p.Name == p.ReflectedType.Name + "ID")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>() // Todo objeto que for do tipo string será considerado varchar
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties().Where(x => x.Name == x.ReflectedType + "flAtivo").Configure(p => p.IsKey());
           
    

            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dataEntradaEstoque") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dataEntradaEstoque").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Property("dataEntradaEstoque").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
      

    }
}

