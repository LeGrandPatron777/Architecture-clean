using Microsoft.EntityFrameworkCore;
using SolutionGestionProjets.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolutionGestionProjets.Infrastructure
{
    public class SolutionGestionProjetsContext : DbContext
    {
        public DbSet<Projet> Projets { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public SolutionGestionProjetsContext(DbContextOptions options) :
                             base(options)
        { }

        public SolutionGestionProjetsContext() : base(new
               DbContextOptionsBuilder<SolutionGestionProjetsContext>()
               .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SolutionGestionProjetsDB;Trusted_Connection=True;")
               .Options)
        { }

    }
}
