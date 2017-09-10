using System;

namespace Proyecto.Core.Models
{
    public class HistorialChildren
    {
        public int IdHistorialChildren { get; set; }
        public string NombreCompleto { get; set; }
        public int IdSexo { get; set; }
        public int EdadAnios { get; set; }
        public int EdadMeses { get; set; }
        public decimal Talla { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public string DetalleIMC { get; set; }
        public decimal PerimCefalico { get; set; }
        public decimal PerimMedioBrazo { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdChildren { get; set; }
    }
}
