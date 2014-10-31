using System;

namespace Biblio.Business.Models
{
    public class ShowRequestModel : SaveRequestModel
    {

        public string RawInput { get; set; }

        public string WordCount { get; set; }

        public string VowelCount { get; set; }

        public string ConsonantCount { get; set; }

        public string SpecialCharacterCount { get; set; }

    }
}
