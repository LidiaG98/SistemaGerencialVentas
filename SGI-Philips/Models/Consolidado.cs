using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Consolidado
    {
        public int consolidadoID { get; set; }
        public string anioConsolidado { get; set; }
        public int ventasConsolidado { get; set; }

        //Llaves Foraneas
        public int productoID { get; set; }
        public Producto Producto  { get; set; }
        public int mesID { get; set; }
        public Mes Mes { get; set; }
    }
}
