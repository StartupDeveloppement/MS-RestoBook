using RestoBook.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestoBook.DAL
{
    public class RestaurantDbContext:DbContext
    {
        public DbSet<Ville> db_ville { get; set; }
        public DbSet<TypeCuisine> db_typecuisine { get; set; }
        public DbSet<Restaurants> db_restaurants { get; set; }
        public DbSet<Adresse> db_addresse { get; set; }
        public DbSet<Notation> db_notation { get; set; }
        public DbSet<Picture> db_Picture { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Restaurants>()
                .HasMany(c => c.TypeCuisines).WithMany(i => i.Restaurants)
                .Map(t => t.MapLeftKey("Id_Restaurant")
                    .MapRightKey("Id_Cuisine")
                    .ToTable("TypeCuisinesRestaurants"));

            modelBuilder.Entity<Restaurants>()
                .HasMany(c => c.Notations).WithMany(i => i.Restaurants)
                .Map(t => t.MapLeftKey("Id_Restaurant")
                    .MapRightKey("Id_Notation")
                    .ToTable("NotationsRestaurants"));

            modelBuilder.Entity<Adresse>()
                .HasRequired<Restaurants>(s => s.Restaurants)
                .WithMany(s => s.Adresses)
                .HasForeignKey(s => s.RestaurantsId);

            modelBuilder.Entity<Adresse>()
                .HasRequired<Ville>(s => s.Villes)
                .WithMany(s => s.Adresses)
                .HasForeignKey(s => s.VilleId);


            modelBuilder.Entity<Picture>()
                .HasRequired<Restaurants>(s => s.Restaurants)
                .WithMany(s => s.Pictures)
                .HasForeignKey(s => s.fk_Restaurant);
                    

        }
    }
}
