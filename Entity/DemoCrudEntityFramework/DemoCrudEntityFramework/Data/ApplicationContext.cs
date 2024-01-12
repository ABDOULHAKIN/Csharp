using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoCrudEntityFramework;

namespace DemoCrudEntityFramework.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    optionsBuilder
        //        .UseSqlServer("Server=(localdb)\\mssqllocaldb;" +
        //        "Database=DemoCrudDb;" +
        //        "MultipleActiveResultSets=true;");
        //}
        public DbSet<DemoCrudEntityFramework.Etudiant> Etudiant { get; set; } = default!;
    }
}
