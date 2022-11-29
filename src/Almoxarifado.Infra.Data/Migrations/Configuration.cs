namespace Almoxarifado.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Almoxarifado.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Almoxarifado.Infra.Data.AlmoxarifadoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


    }


}


