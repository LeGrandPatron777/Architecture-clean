using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel.Interfaces;
using SystèmeGestionStationService.SharedKernel;

namespace SolutionGestionProjets.Core.Entities
{
    public class Gestionnaire : Utilisateur
    {
        public Gestionnaire(int matricule, string nom, string prenom, string adresse, int telephone, DateTime dateEmbauche, string nomConnexion, string motDePasse) : base(matricule, nom, prenom, adresse, telephone, dateEmbauche, nomConnexion, motDePasse)
        {
        }
    }
}
