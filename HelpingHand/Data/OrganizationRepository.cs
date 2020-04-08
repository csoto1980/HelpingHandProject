using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpingHand.Library.Contracts;
using HelpingHand.Library;
using HelpingHand.Library.Models;

namespace HelpingHand.Data
{
    public class OrganizationRepository : RepositoryBase<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }
    }
}
