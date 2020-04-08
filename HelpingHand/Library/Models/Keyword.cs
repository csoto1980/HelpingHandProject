using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHand.Library.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public ICollection<DonorKeyword> DonorKeywords { get; set; }
        public ICollection<OrganizationKeyword> OrganizationKeywords { get; set; }

    }
}
