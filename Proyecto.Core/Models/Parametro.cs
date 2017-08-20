using System;

namespace Proyecto.Core.Models
{
    public class Parametro
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Grupo { get; set; }
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public DateTime CreadoEn { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime ModificadoEn { get; set; }
    }
}
