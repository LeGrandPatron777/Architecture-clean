using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel;
using SystèmeGestionStationService.SharedKernel.Interfaces;


namespace SolutionGestionProjets.Core.Entities
{
    public class Projet : BaseEntity, IAggregateRoot
    {
        public int Numero { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public float BudgetTotal { get; set; }
        public Projet(int numero, DateTime dateDebut, DateTime dateFin, float budgetTotal)
        {
            Numero = numero;
            DateDebut = dateDebut;
            DateFin = dateFin;
            BudgetTotal = budgetTotal;
        }
    }
}
