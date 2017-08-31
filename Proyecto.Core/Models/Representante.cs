using System;

namespace Proyecto.Core.Models
{
    public class Representante
    {
        public int IdRepresentante { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public decimal? Talla { get; set; }
        public int? Peso { get; set; }
        public int? NHijos { get; set; }
        public int IdUsuario { get; set; }
        public int? IdParentesco { get; set; }
        public int? IdNacionalidad { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdCiudad { get; set; }
    }
}
