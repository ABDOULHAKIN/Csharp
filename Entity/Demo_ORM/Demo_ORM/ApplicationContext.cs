using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_ORM
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
       

        // Definir la chaine de connexion 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // pour lui indiquer notre BDD

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Module7ConsoleDb;MultipleActiveResultSets=true;");
        }
    }
}
