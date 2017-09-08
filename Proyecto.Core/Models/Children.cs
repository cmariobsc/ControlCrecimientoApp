using System;

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
        public int EdadAnos { get; set; }
        public int EdadMeses { get; set; }
        public decimal Talla { get; set; }
        public int Peso { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdRepresentante { get; set; }
    }
}
