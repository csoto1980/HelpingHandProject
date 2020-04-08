using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpingHand.Data;
using HelpingHand.Library.Contracts;

namespace HelpingHand.Library
{

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private IAddressRepository _address;
        private IDonorRepository _donor;
        private IKeywordRepository _keyword;
        private IOrganizationRepository _organization;

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_context);
                }
                return _address;
            }
        }
        public IDonorRepository Donor
        {
            get
            {
                if (_donor == null)
                {
                    _donor = new DonorRepository(_context);
                }
                return _donor;
            }
        }
        public IKeywordRepository Keyword
        {
            get
            {
                if (_keyword == null)
                {
                    _keyword = new KeywordRepository(_context);
                }
                return _keyword;
            }
        }
        public IOrganizationRepository Organization
        {
            get
            {
                if (_organization == null)
                {
                    _organization = new OrganizationRepository(_context);
                }
                return _organization;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

