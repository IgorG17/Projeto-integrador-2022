using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Almoxarifado.Domain.Entities;
using System.Data.Entity.Infrastructure.Annotations; // Permite usar IndexAnnotation
using System.ComponentModel.DataAnnotations.Schema; // Permite usar IndexAttribute

namespace Almoxarifado.Infra.Data.Entity_Config
{

    public class GuiaConfiguration : EntityTypeConfiguration<Guia>
    {
        public GuiaConfiguration()
        {
            HasKey(p => p.idGuia);
            Property(n => n.numeroGuia)
                .IsRequired();

            Property(n => n.dataGuia)
                .IsRequired();

            Property(e => e.dataValidadeGuia)
                .IsRequired();

            Property(c => c.flAtivo)
                .IsRequired();

            Property(c => c.motiSituacaoGuia)
               .HasMaxLength(50);

            Property(c => c.justificativaGuia)
               .IsRequired()
               .HasMaxLength(50);            

            ToTable("Guias");
        }
    }
   
}
