using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Qks.Web.Mvc.Areas.Admin.Controllers
{
    [Area(QksConsts.AdminAreaName)]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}