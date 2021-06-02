using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class TotalRotacion
    { public int totalRotacionID { get; set; }
      public double invCosto { get; set; }
      public double invVenta { get; set; }
      public double pedidoCompra { get; set; }
      public double backOrderTotal { get; set; }

       //foreign Key ---- UwU ----- Si estás leyendo esto, te quiero <3 
      //
     // public int rotacionID { get; set; }
      public Rotacion rotacion { get; set; }
      



    }
}
