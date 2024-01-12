using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Festival.BO;

namespace Festival.Web.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Festival.BO.Artiste> Artiste { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Groupe>().HasData(new BO.Groupe()
            {
                Id = 1,
                Nom = "Queen 2024",
                DateCreation = new DateTime(1997,11,24)
            });

            modelBuilder.Entity<Artiste>().HasData(new BO.Artiste()
            {
                Id = 1,
                Nom = "Mercury",
                Prenom = "Freddy",
                Instrument = "Piano",
                GroupeId = 1,
            });

            modelBuilder.Entity<Artiste>().HasData(new BO.Artiste()
            {
                Id = 2,
                Nom = "Quentin",
                Prenom = "Martinez",
                Instrument = "Code",
            });

        }

        public DbSet<Festival.BO.Groupe>? Groupe { get; set; }

    }
}
