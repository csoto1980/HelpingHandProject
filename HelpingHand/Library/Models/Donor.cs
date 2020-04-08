using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHand.Library.Models
{
    public class Donor
    {
        public int DonorId { get; set; }
        [Display(Name = "Donor Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        //[ForeignKey("Keyword")]
        //[Display(Name = "Keyword")]
        //public ICollection<Keyword> Keywords { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public ICollection<DonorKeyword> DonorKeywords { get; set; }
    }
}
