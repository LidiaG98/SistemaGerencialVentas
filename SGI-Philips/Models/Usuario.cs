using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Usuario : IdentityUser
    {
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string dui { get; set; }
        public string nit { get; set; }
        public string nup { get; set; }
        public DateTime fechaNacimiento { get; set; }
        // Los siguientes atributos son para la relación 1 a * entre Usuario y Puesto
        public int idPuesto { get; set; }
        public Puesto puesto { get; set; }
    }
}
