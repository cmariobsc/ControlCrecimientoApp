using System;

namespace Proyecto.Core.Models
{
    public class HistorialChildren
    {
        public int IdHistorialChildren { get; set; }
        public string NombreCompleto { get; set; }
        public int EdadAnos { get; set; }
        public int EdadMeses { get; set; }
        public decimal Talla { get; set; }
        public int Peso { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdChildren { get; set; }
    }
}
