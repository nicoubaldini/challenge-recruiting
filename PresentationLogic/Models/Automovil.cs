using Enums.PresentationLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Models
{
    public class Automovil : Vehiculo
    {
        public int IdAutomovil { get; set; }
        public TipoAutomovil Tipo { get; set; }
        public int CantPuertas { get; set; }

    }
}
