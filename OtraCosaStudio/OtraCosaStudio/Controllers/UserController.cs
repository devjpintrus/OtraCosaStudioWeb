using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtraCosaStudio.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Users()
        {
            return View();
        }
    }
}