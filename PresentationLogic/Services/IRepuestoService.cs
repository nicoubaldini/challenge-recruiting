using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public interface IRepuestoService
    {
        Repuesto GetRepuesto(int id);

        List<Repuesto> GetAllRepuestos();
        List<Repuesto> GetRepuestosFromDesperfecto(int idRepuesto);

        void InsertRepuesto(Repuesto desperfectoToInsert);

        void UpdateRepuesto(Repuesto desperfectoToUpdate);

        void DeleteRepuesto(int id);
    }
}
