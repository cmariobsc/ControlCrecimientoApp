using Proyecto.Core.Enumerations;


namespace Proyecto.Core.Models.Auth
{
    public class User
    {
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public TipoPerfil Perfil { get; set; }
        public string Producto { get; set; }
    }
}
