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
    public class HomeController : Controller
    {
        public ViewResult Index()
        {

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return View("index", "error", new ErrorModel() { ErrorMessage = ex.Message });
            }

        }

        public ViewResult Show(ShowRequestModel request)
        {

            try
            {

                // process incoming request here, package results into a response view model ...

                BiblioService svc = new BiblioService();

                ResponseModel response = new ResponseModel
                {
                    Duplicate = request.Duplicate,
                    Palindrome = request.Palindrome,
                    RawInput = request.RawInput
                };

                if (!svc.validate(request))
                {
                    response.HasError = true;
                    response.CanSave = false;
                    response.ErrorMessage = svc.ErrorMessage;
                }

                return View(response);

            }
            catch (Exception ex)
            {
                return View("index", "error", new ErrorModel() { ErrorMessage = ex.Message });
            }
            
        }

        public ViewResult Save(SaveRequestModel request)
        {

            try
            {

                MemoryStream ms = new MemoryStream();
                TextWriter tw = new StreamWriter(ms);
                tw.WriteLine("Palindromes :");
                tw.WriteLine(request.Palindrome);
                tw.WriteLine("");
                tw.WriteLine("Duplicates :");
                tw.WriteLine(request.Duplicate);
                tw.Flush();
                byte[] bytes = ms.ToArray();
                ms.Close();

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=export.txt");
                Response.BinaryWrite(bytes);
                Response.End();

                // never gets here
                return View();

            }
            catch (Exception ex)
            {
                return View("index", "error", new ErrorModel() { ErrorMessage = ex.Message });
            }

        }
    }
}
