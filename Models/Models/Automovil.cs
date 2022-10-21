using Enums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Automovil : Vehiculo
    {
        public int IdAutomovil { get; set; }
        public TipoAutomovil Tipo { get; set; }
        public int CantPuertas { get; set; }

    }
}
