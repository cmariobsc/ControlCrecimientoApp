
namespace Proyecto.Web.Core.Models
{
    public class ApiResult
    {
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ApiResult()
        {
        }
        public ApiResult(string status, string errorCode, string message)
        {
            this.Status = status;
            this.ErrorCode = errorCode;
            this.Message = message;
        }
        public ApiResult(string status, string errorCode, string message, object data)
        {
            this.Status = status;
            this.ErrorCode = errorCode;
            this.Message = message;
            this.Data = data;
        }
    }
}
