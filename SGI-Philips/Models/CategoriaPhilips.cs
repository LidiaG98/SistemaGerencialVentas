using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class CategoriaPhilips
    {
        public int categoriaPhilipsID { get; set; }

        public string nombreCategoria { get; set; }

        //Foraneas
        public ICollection<ProductoPhilips> ProductoPhilips { get; set; }
    }
}
