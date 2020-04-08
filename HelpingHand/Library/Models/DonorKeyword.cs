using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHand.Library.Models
{
    public class DonorKeyword
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

    }
}
