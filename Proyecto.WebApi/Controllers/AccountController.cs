using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace Proyecto.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        public AccountController() { }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // hacer custom dispose
            }
            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
            }
            return null;
        }
    }
}