using Microsoft.AspNetCore.Antiforgery;
using Qks.Controllers;

namespace Qks.Web.Host.Controllers
{
    public class AntiForgeryController : QksControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
