using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel.Interfaces;
using SystèmeGestionStationService.SharedKernel;

namespace SolutionGestionProjets.Core.Entities
{
    public class Client : BaseEntity, IAggregateRoot
    {
        public int Numero { get; set; }
        public string NomCompagnie { get; set; }

        public string Adresse {  get; set; }
        public int Telephone { get; set; }

        public Client (int numero, string nomCompagnie, string adresse, int telephone) { 

            Numero = numero;
            NomCompagnie = nomCompagnie;
            Adresse = adresse;
            Telephone = telephone; 
        }
    }
}
