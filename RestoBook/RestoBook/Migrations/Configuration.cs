namespace RestoBook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestoBook.DAL.RestaurantDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestoBook.DAL.RestaurantDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.db_typecuisine.AddOrUpdate(
    p => p.lb_cuisne,
    new Models.TypeCuisine { lb_cuisne = "Italien" },
    new Models.TypeCuisine { lb_cuisne = "Espagnol" },
    new Models.TypeCuisine { lb_cuisne = "Libanais" },
    new Models.TypeCuisine { lb_cuisne = "Grecque" },
    new Models.TypeCuisine { lb_cuisne = "Chinois" },
    new Models.TypeCuisine { lb_cuisne = "Japonais" },
    new Models.TypeCuisine { lb_cuisne = "Créole" },
    new Models.TypeCuisine { lb_cuisne = "Vietnamien" },
    new Models.TypeCuisine { lb_cuisne = "Cambogien" },
    new Models.TypeCuisine { lb_cuisne = "Thailandaise" },
    new Models.TypeCuisine { lb_cuisne = "Française" }
    );

            context.db_ville.AddOrUpdate(
                p => p.lb_ville,
                new Models.Ville { lb_ville = "Paris" },
                new Models.Ville { lb_ville = "Lyon" },
                new Models.Ville { lb_ville = "Toulouse" },
                new Models.Ville { lb_ville = "Bordeaux" },
                new Models.Ville { lb_ville = "Marseille" },
                new Models.Ville { lb_ville = "Lille" },
                new Models.Ville { lb_ville = "Versailles" },
                new Models.Ville { lb_ville = "Montpellier" },
                new Models.Ville { lb_ville = "Aix-en-Provence" }
                );

            context.SaveChanges();
        }
    }
}
