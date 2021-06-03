using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class HistorialDeActividad
    {
        public int historialDeActividadID { get; set; }
        //decidí ponerle tipo de actividad porque suena más intuitivo que comentario Actividad 
        public string tipoActividad { get; set; }
        public DateTime fechaCreación { get; set; }

        //no sé para que era este atributo v:
       public DateTime fechaActualización { get; set; }
        //Foreign Key
        public string Id { get; set; }
        public Usuario usuario { get; set; }
                //[ForeignKey("UserId")]
        //public ApplicationUser ApplicationUser { get; set; }
    }
}
