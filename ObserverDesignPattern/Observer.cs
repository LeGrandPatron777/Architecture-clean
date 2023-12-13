using System;
namespace SystèmeGestionStationService.Core
{
    public interface Observer
    {
        void Update(object subject);
    }
}