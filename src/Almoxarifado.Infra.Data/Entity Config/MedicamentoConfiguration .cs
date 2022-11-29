//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity.ModelConfiguration;
//using Almoxarifado.Domain.Entities;
//using System.Data.Entity.Infrastructure.Annotations; // Permite usar IndexAnnotation
//using System.ComponentModel.DataAnnotations.Schema; // Permite usar IndexAttribute

//namespace Almoxarifado.Infra.Data.Entity_Config
//{

//    public class MedicamentoConfiguration : EntityTypeConfiguration<Medicamento>
//    {
//        public MedicamentoConfiguration()
//        {
//            HasKey(p => p.idMedicamento);

//            Property(n => n.nomeMedicamento)
//                .IsRequired()
//                .HasMaxLength(40);


//            Property(c => c.idTipoMedicamento)
//                .IsRequired();


//            ToTable("Medicamentos");
//        }



//    }
//    public class TipoMedicamentoConfiguration : EntityTypeConfiguration<TipoMedicamento>
//    {
//        public TipoMedicamentoConfiguration()
//        {
//            Property(n => n.idTipoMedicamento)
//                .IsRequired();

//            Property(n => n.nomeTipoMedicamento)
//                .IsRequired()
//                .HasMaxLength(50);

//            Property(c => c.flAtivo)
//                .IsRequired();

//            ToTable("TipoMedicamento");
//        }



//    }


//}
