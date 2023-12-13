using SolutionGestionProjets.Core.Entities;
using SolutionGestionProjets.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using SolutionGestionProjets.Infrastructure.Repositories;
using System.Threading.Tasks; // Ajouté pour Task
using SystèmeGestionStationService.SharedKernel.Interfaces;

namespace SolutionGestionProjets.ConsoleTestApp
{
    class Program
    {
        static async Task Main(string[] args) // Main est maintenant async Task
        {
            

            await Test2(); // Attendre l'exécution de Test2 qui est une méthode asynchrone
        }

        static void Test1()
        {
            using (var context = new SolutionGestionProjetsContext()) // Utilisation d'un bloc using pour la disposition correcte
            {
                // Ajouter un projet
                Projet projet = new Projet("smane"); // Assurez-vous que le constructeur prend un string comme argument
                context.Add(projet);

                context.SaveChanges();
            }
        }

        static async Task Test2()
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                IAsyncRepository<Projet> repository = new EfRepository<Projet>(context);
                Projet projet = await repository.GetByIdAsync(2);
                if (projet != null)
                    Console.WriteLine(projet.Name);
                else
                    Console.WriteLine("Projet introuvable");
            }
        }
    }
}
