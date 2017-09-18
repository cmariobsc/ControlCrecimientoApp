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
        public int EdadAnios { get; set; }
        public int EdadMeses { get; set; }
        public int EdadTotalMeses { get; set; }
        public decimal Talla { get; set; }
        public decimal Peso { get; set; }
        public decimal IMC { get; set; }
        public string DetalleIMC { get; set; }
        public decimal PerimCefalico { get; set; }
        public decimal PerimMedioBrazo { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdSexo { get; set; }
        public int IdRepresentante { get; set; }
    }
}
