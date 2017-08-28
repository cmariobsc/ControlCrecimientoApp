
namespace Proyecto.Web.Core.Models
{
    public class ApiResult
    {
        public string Status { get; set; }
        public string codError { get; set; }
        public string mensajeRetorno { get; set; }
        public object Data { get; set; }

        public ApiResult()
        {
        }
        public ApiResult(string status, string codError, string mensajeRetorno)
        {
            this.Status = status;
            this.codError = codError;
            this.mensajeRetorno = mensajeRetorno;
        }
        public ApiResult(string status, string codError, string mensajeRetorno, object data)
        {
            this.Status = status;
            this.codError = codError;
            this.mensajeRetorno = mensajeRetorno;
            this.Data = data;
        }
    }
}
