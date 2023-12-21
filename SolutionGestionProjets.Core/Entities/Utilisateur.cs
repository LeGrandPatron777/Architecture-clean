using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel.Interfaces;
using SystèmeGestionStationService.SharedKernel;

namespace SolutionGestionProjets.Core.Entities
{
    public class Utilisateur : BaseEntity, IAggregateRoot
    {
        public int Matricule { get; set; }
        public string Nom {  get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }

        public int Telephone { get; set; }

        public DateTime DateEmbauche { get; set; }

        public string NomConnexion { get; set; }

        public string MotDePasse { get; set; }

        public Utilisateur(int matricule, string nom, string prenom, string adresse, int telephone, DateTime dateEmbauche, string nomConnexion, string motDePasse) 
        {
            Matricule = matricule;
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Telephone = telephone;
            DateEmbauche = dateEmbauche;
            NomConnexion = nomConnexion;
            MotDePasse= motDePasse;
        }
    }
}
