using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHand.Library.Contracts
{
    public interface IRepositoryWrapper
    {
        IAddressRepository Address { get; }
        IDonorRepository Donor { get; }
        IKeywordRepository Keyword { get; }
        IOrganizationRepository Organization { get; }
        void Save();
    }
}
