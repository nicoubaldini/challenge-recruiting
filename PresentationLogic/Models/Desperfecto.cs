using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLogic.Models
{
    public class Desperfecto
    {
        public int IdDesperfecto { get; set; }
        public int IdVehiculo { get; set; }
        public string Descripcion { get; set; }
        public double ManoObra { get; set; }
        public int TiempoDias { get; set; }
    }
}
