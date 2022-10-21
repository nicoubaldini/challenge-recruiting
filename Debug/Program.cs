using Models;
using Models.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debug
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var cs = ConfigurationManager.ConnectionStrings["ChallengeRecruitingDB"].ConnectionString;

            //IVehiculoService vehiculoService = new VehiculoService(cs);
            IAutomovilService automovilServices  = new AutomovilService(cs);
            IMotoService motoService = new MotoService(cs);

            Moto m = new Moto()
            {
                IdMoto = 6,
                Cilindrada = false,
                Marca = "8",
                Modelo = "8",
                Patente = "8-dsadas"
            };

            motoService.DeleteMoto(5);

            var aa = motoService.GetAllMotos();

            foreach (var a in aa)
            {
                Console.WriteLine(a.IdMoto +  " - " + a.Cilindrada.ToString() + " - " + a.Marca + " - " + a.Modelo + " - " + a.Patente);
                
            }
            Console.ReadLine();
        }
    }
}
