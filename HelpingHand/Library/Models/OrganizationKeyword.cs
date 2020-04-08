using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHand.Library.Models
{
    public class OrganizationKeyword
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
    }
}
