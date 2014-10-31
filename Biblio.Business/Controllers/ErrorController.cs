using Biblio.Business.Models;
using Biblio.Business.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace Biblio.Business.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(ErrorModel model)
        {
            return View(model);
        }
    }
}
