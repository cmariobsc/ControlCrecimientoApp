using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using Proyecto.Web.Core.Models;

namespace Proyecto.Web.Core.Controllers
{
    [Authorize]
    public class BaseApiController : ApiController
    {
        public ProyectoClaims ProyectoClaims => GetClaims();
        private ProyectoClaims GetClaims()
        {
            var principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            if (principal == null) return null;

            if (principal.Identity.IsAuthenticated)
            {
                var proClaims = new ProyectoClaims();
                proClaims.Username = principal.Identity.Name;
                proClaims.Sub = principal.Claims.Single(c => c.Type == "sub").Value;
                proClaims.Nombre = principal.Claims.Single(c => c.Type == "nombre").Value;
                proClaims.Usuario = principal.Claims.Single(c => c.Type == "usuario").Value;
                proClaims.Perfil = principal.Claims.Single(c => c.Type == "perfil").Value;
                proClaims.Producto = principal.Claims.Single(c => c.Type == "producto").Value;

                return proClaims;
            }

            return null;
        }

        public String GetIp4Address()
        {
            HttpContext context = HttpContext.Current;
            return (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? context.Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
        }
    }
}
