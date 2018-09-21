using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Challenge3.API.Models;
using Microsoft.AspNet.Identity;

namespace Challenge3.API.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        private Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult YourModules()
        {
            ViewBag.Message = "Here are the modules you are responsible for:";

            var userId = User.Identity.GetUserId();
            List<UserModule> modules = new List<UserModule>(db.UserModules.Where(u => u.Id == userId));

            ViewBag.Modules = modules;

            return View();
        }

    }
}