using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Proyeccion
    {
        public int proyeccionID { get; set; }
        public string anioProyeccion { get; set; }
        public int ventasProyeccion { get; set; }

        //Llave Foranea
        public int productoID { get; set; }
        public Producto Producto { get; set; }
        public int mesID { get; set; }
        public Mes Mes { get; set; }
    }
}
