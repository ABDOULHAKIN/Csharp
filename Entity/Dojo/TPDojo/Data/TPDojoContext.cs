using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BO;

namespace TPDojo.Data
{
    public class TPDojoContext : DbContext
    {
        public TPDojoContext (DbContextOptions<TPDojoContext> options)
            : base(options)
        {
        }

        public DbSet<BO.Arme> Arme { get; set; }

        public DbSet<BO.Samourai> Samourai { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Samourai>().HasMany(s => s.ArtsMartiaux)
                                        .WithMany(a => a.Pratiquants)
                                        .UsingEntity("Pratiques");
            modelBuilder.Entity<Samourai>().Ignore(s => s.Potentiel);
        }

        public DbSet<BO.ArtMartial>? ArtMartial { get; set; }
    }
}
