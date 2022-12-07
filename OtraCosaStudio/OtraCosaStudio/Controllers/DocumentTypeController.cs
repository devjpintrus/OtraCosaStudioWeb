using OtraCosaStudio.Model;
using OtraCosaStudio.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtraCosaStudio.Controllers
{
    public class DocumentTypeController : Controller
    {

        public JsonResult GetListDocumentTypes()
        {
            var list = ServiceManager<DocumentTypeSvc>.Provider.ToListDocumentType();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
