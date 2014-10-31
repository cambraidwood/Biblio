using System;

namespace Biblio.Business.Models
{
    public class ResponseModel
    {

        public string RawInput { get; set; }

        public string Palindrome { get; set; }

        public string Duplicate { get; set; }

        public bool CanSave { get; set; }

        public bool HasError { get; set; }

        public string ErrorMessage { get; set; }

        public ResponseModel()
        {
            RawInput = string.Empty;
            Palindrome = string.Empty;
            Duplicate = string.Empty;
            CanSave = true;
            HasError = false;
            ErrorMessage = string.Empty;
        }

    }
}
