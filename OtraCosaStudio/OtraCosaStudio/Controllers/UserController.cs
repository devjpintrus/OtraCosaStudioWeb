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
            var list = ServiceManager<UserSvc>.Provider.ToListUser();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult FindUser(int Id)
        {
            var res = ServiceManager<UserSvc>.Provider.FindUserById(Id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveUser(User user)
        { 
            var res = ServiceManager<UserSvc>.Provider.RegisterUser(user);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateUser(User user)
        { 
            var res = ServiceManager<UserSvc>.Provider.UpdateUser(user);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteUser(int Id)
        { 
            var res = ServiceManager<UserSvc>.Provider.DeleteUser(Id);
            return Json(res, JsonRequestBehavior.AllowGet);
        }


    }
}