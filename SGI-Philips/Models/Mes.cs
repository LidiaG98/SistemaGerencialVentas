using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Mes
    {
        public int mesID { get; set; }

        public string nombreMes { get; set; }
        public ICollection<Consolidado> Consolidados { get; set; }
        public ICollection<Proyeccion> Proyeccions { get; set; }
    }
}
