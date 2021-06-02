using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class ProductoPhilips
    {
        public int productoPhilipsID { get; set; }

        public double precio { get; set; }

        public string codigoPhillips { get; set; }

        public string descripcionPhillips { get; set; }
        
        //Foranias
        public int categoriaPhilipsID { get; set; }
        public CategoriaPhilips CategoriaPhilips { get; set; }
        public int productoID { get; set; }
        public Producto Producto { get; set; }

       


    }
}
