
using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public interface IAutomovilService
    {
        Automovil GetAutomovil(int id);

        List<Automovil> GetAllAutomoviles();

        void InsertAutomovil(Automovil vehiculoToInsert);

        void UpdateAutomovil(Automovil vehiculoToUpdate);

        void DeleteAutomovil(int id);
    }
}
