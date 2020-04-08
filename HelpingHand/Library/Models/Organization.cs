using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HelpingHand.Library.Models;

namespace HelpingHand.Library.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        
        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [ForeignKey("Address")]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Items Needed")]
        [Display(Name = "Items Needed")]
        public int? ItemId { get; set; }
        public ICollection<Item> Items { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public ICollection<OrganizationKeyword> OrganizationKeywords { get; set; }

    }




}
