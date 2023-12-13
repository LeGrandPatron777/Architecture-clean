using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystèmeGestionStationService.SharedKernel;
using SystèmeGestionStationService.SharedKernel.Interfaces;

namespace SolutionGestionProjets.Core.Entities
{
    public class Projet : BaseEntity, IAggregateRoot
    {
       
        public string Name { get; set; }

        public Projet(string Name)
        {
            this.Name = Name; 
        }
    }
}
