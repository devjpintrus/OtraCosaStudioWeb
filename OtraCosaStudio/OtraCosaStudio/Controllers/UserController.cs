using OtraCosaStudio.Model;
using OtraCosaStudio.Services.Interfaces;
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


        public JsonResult GetListUsers()
        { 
            var lista = ServiceManager<UserSvc>.Provider.ToListUser();
            return Json(lista, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveUser(User user)
        { 
            var res = ServiceManager<UserSvc>.Provider.RegisterUser(user);
            return Json(res, JsonRequestBehavior.AllowGet);
        }


    }
}