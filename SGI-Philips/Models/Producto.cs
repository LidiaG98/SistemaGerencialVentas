using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Producto
    {
        public int productoID { get; set; }
        public string codigoProducto { get; set; }
        public string descripcion { get; set; }
        public int stock { get; set; }
        public float costoP { get; set; }
        public int backOrder { get; set; }

        //Foreign Key ------------------
        public int  rotacionID { get; set; }
        public Rotacion rotacion { get; set; }

        //public int productoPhilipsID { get; set; }
        public ProductoPhilips ProductoPhilips { get; set; }
        
        
        public ICollection<Consolidado> Consolidados { get; set; }
        public ICollection<Proyeccion> Proyeccions { get; set; }

    }
}
