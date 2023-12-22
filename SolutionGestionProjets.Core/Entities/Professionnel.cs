using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionGestionProjets.Core.Entities
{
    public class Professionnel : Utilisateur
    {
        public Professionnel(int matricule, string nom, string prenom, string adresse, int telephone, DateTime dateEmbauche, string nomConnexion, string motDePasse) : base(matricule, nom, prenom, adresse, telephone, dateEmbauche, nomConnexion, motDePasse)
        {
        }
    }
}
