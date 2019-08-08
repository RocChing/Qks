using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Qks.Controllers;

namespace Qks.Web.Controllers
{
    [Area(QksConsts.AdminAreaName)]
    [AbpMvcAuthorize]
    public class HomeController : QksControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
