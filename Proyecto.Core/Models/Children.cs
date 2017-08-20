using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Core.Models
{
    public class Children
    {
        public int IdChildren { get; set; }
        public string Identificacion { get; set; }
        public int IdNacionalidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public double Talla { get; set; }
        public int Peso { get; set; }
    }
}
