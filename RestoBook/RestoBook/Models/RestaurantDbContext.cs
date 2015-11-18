using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoBook.Models
{
    public class RestaurantDbContext:DbContext
    {
        public DbSet<Ville> db_ville { get; set; }
        public DbSet<TypeCuisine> db_typecuisine { get; set; }
        public DbSet<Restaurants> db_restaurants { get; set; }
        public DbSet<Adresse> db_addresse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Restaurants>()
                .HasMany(c => c.TypeCuisines).WithMany(i => i.Restaurants)
                .Map(t => t.MapLeftKey("Id_Restaurant")
                    .MapRightKey("Id_Cuisine")
                    .ToTable("TypeCuisinesRestaurants"));

            modelBuilder.Entity<Adresse>()
                .HasRequired<Restaurants>(s => s.Restaurants)
                .WithMany(s => s.Adresses)
                .HasForeignKey(s => s.RestaurantsId);

            modelBuilder.Entity<Adresse>()
                .HasRequired<Ville>(s => s.Villes)
                .WithMany(s => s.Adresses)
                .HasForeignKey(s => s.VilleId);
                

        }
    }
}
