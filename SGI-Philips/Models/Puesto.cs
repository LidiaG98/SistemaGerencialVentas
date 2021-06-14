using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Puesto
    {
        public int puestoID { get; set; }
        public string nombrePuesto { get; set; }

        // Esto es para la relacion 1 a * entre usuario y puesto
        public ICollection<Usuario> usuario { get; set; }
    }
}
