namespace Proyecto.Core.Models.Catalogos
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string LugarTrabajo { get; set; }
        public int IdProvincia { get; set; }
        public int IdCiudad { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
    }
}
