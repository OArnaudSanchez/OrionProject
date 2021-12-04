
using Microsoft.EntityFrameworkCore;
using OrionProject.Core.Models;

namespace OrionProject.Infrastructure.Context
{
    public class OrionProjectContext : DbContext
    {
        public OrionProjectContext(DbContextOptions<OrionProjectContext> options) : base(options) { }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity => {
                entity.ToTable("Client");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name);
                
                entity.Property(x => x.LastName);
                
                entity.Property(x => x.BirthDate);

                entity.Property(x => x.Email);
            });

            modelBuilder.Entity<Address>(entity => {
                entity.ToTable("Address");

                entity.HasKey(x => x.Id);
                
                entity.Property(x => x.City);
                
                entity.Property(x => x.StreetName);
                
                entity.Property(x => x.StreetNumber);

                entity.Property(x => x.PostalCode);
                
                entity.HasOne(c => c.Client)
                    .WithMany(c => c.Addresses)
                    .HasForeignKey(c => c.IdClient)
                    .HasConstraintName("FK_Address_Client");
            });
        }
    }
}
