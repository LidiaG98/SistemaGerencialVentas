using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGI_Philips.Models
{
    public class Rotacion
    {
        public int rotacionID { get; set; }
        public string tipo { get; set; }
        public float mesesInv { get; set; }
        //Foreign key  -----Please Dont GO ------- Dont goooooooooooooooooooooooooooooooooooooooooooooooo--
        public int totalrotacionID { get; set; }
        public TotalRotacion totalRotacion { get; set; }
    }
}
