using System;
namespace SystèmeGestionStationService.Core
{
    public interface Subject
    {
        public void Attach(Observer o);
        public void Detach(Observer o);
        public void Notify();

    }
}