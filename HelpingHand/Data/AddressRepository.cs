using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpingHand.Library.Contracts;
using HelpingHand.Library;
using HelpingHand.Library.Models;

namespace HelpingHand.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
    }
}
