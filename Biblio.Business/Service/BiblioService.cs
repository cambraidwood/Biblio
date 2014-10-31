using Biblio.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.Business.Service
{
    public class BiblioService
    {

        public BiblioService() { }

        public string ErrorMessage = string.Empty;

        public bool validate(ShowRequestModel request)
        {

            // some business validation

            bool ok = true;

            if (string.IsNullOrEmpty(request.Duplicate) && string.IsNullOrEmpty(request.Palindrome))
            {
                ErrorMessage = "Nothing to Save !";
                ok = false;
            }

            if (ok)
                return true;

            return (false);
        }

    }
}
