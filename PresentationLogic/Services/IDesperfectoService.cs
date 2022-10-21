using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public interface IDesperfectoService
    {
        
        Desperfecto GetDesperfecto(int id);

        List<Desperfecto> GetAllDesperfectos();
        List<Desperfecto> GetDesperfectosFromRepuesto(int idRepuesto);
        List<Desperfecto> GetDesperfectosFromVehiculo(int idVehiculo);

        void InsertDesperfecto(Desperfecto desperfectoToInsert);

        void UpdateDesperfecto(Desperfecto desperfectoToUpdate);

        void DeleteDesperfecto(int id);
    }
}
