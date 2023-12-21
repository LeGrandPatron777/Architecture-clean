using SolutionGestionProjets.Core.Entities;
using SolutionGestionProjets.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using SolutionGestionProjets.Infrastructure.Repositories;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel.Interfaces;

namespace SolutionGestionProjets.ConsoleTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Exemples d'appels des méthodes
            await AddProjet(new Projet(1, new DateTime(2023, 01, 01), new DateTime(2024, 01, 02), 100000));
            await UpdateProjet(1, new DateTime(2023, 02, 01), new DateTime(2024, 02, 02), 1202440);
            await GetProjet(1);
            await DeleteProjet(1);

            await AddUtilisateur(new Utilisateur(1, "Dupont", "Jean", "123 rue de Paris", 0123456789, new DateTime(2020, 01, 01), "jdupont", "password123"));
            bool isAuthenticated = await AuthenticateUser("jdupont", "password123");
            Console.WriteLine(isAuthenticated ? "Authentification réussie" : "Échec de l'authentification");
        }

        static async Task AddProjet(Projet projet)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                context.Add(projet);
                await context.SaveChangesAsync();
                Console.WriteLine("Projet ajouté");
            }
        }

        static async Task GetProjet(int id)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                var projet = await context.Projets.FindAsync(id);
                if (projet != null)
                    Console.WriteLine($"Budget du projet : {projet.BudgetTotal}");
                else
                    Console.WriteLine("Projet introuvable");
            }
        }

        static async Task UpdateProjet(int id, DateTime newDateDebut, DateTime newDateFin, float newBudgetTotal)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                var projet = await context.Projets.FindAsync(id);
                if (projet != null)
                {
                    projet.DateDebut = newDateDebut;
                    projet.DateFin = newDateFin;
                    projet.BudgetTotal = newBudgetTotal;
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Projet introuvable pour la mise à jour");
                }
            }
        }

        static async Task DeleteProjet(int id)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                var projet = await context.Projets.FindAsync(id);
                if (projet != null)
                {
                    context.Projets.Remove(projet);
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Projet introuvable pour la suppression");
                }
            }
        }

        static async Task AddUtilisateur(Utilisateur utilisateur)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                context.Utilisateurs.Add(utilisateur);
                await context.SaveChangesAsync();
                Console.WriteLine("Utilisateur ajouté");
            }
        }

        static async Task<bool> AuthenticateUser(string nomConnexion, string motDePasse)
        {
            using (var context = new SolutionGestionProjetsContext())
            {
                var utilisateur = await context.Utilisateurs
                                    .FirstOrDefaultAsync(u => u.NomConnexion == nomConnexion);

                if (utilisateur != null && utilisateur.MotDePasse == motDePasse)
                {
                    return true; // Authentification réussie
                }

                return false; // Échec de l'authentification
            }
        }
    }


}
