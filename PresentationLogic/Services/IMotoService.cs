
using PresentationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Services
{
    public interface IMotoService
    {
        Moto GetMoto(int id);

        List<Moto> GetAllMotos();

        void InsertMoto(Moto motoToInsert);

        void UpdateMoto(Moto motoToUpdate);

        void DeleteMoto(int id);
    }
}
