using Proyecto.Core.Enumerations;


namespace Proyecto.Core.Models.Auth
{
    public class User
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
    }
}
