
using _0_Framework.InfraStructure;
using AccountManagement.Application.Contract.Profile;
using AccountManagement.Domain.ProfileAgg;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class ProfileRepository : RepositoryBase<long, Profile>, IProfileRepository
    {
        private readonly AccountContext _context;

        public ProfileRepository(AccountContext context) : base(context)
        {
            _context = context;
        }
        public Profile GetBy(string email)
        {
            return _context.Profiles.FirstOrDefault(x => x.Email == email);
        }

        public EditProfile GetDeatails(long id)
        {
            return _context.Profiles.Select(x => new EditProfile
            {
                Id = x.Id,
                City = x.City,
                CompanyName = x.CompanyName,
                Contry = x.Contry,
                Email = x.Email,
                Region = x.Region,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ProfileViewModel> GetProfiles()
        {
            return _context.Profiles.Select(x => new ProfileViewModel
            {
                Id = x.Id,
                FullName = x.Account.FullName,
                City = x.City,
                CompanyName = x.CompanyName,
                Contry = x.Contry,
                Email = x.Email,
                PictureCoworker = x.PictureCoworker,
                Region = x.Region,
                Status = x.Status
            }).ToList();
        }

        public List<ProfileViewModel> Search(ProfileSearchModel searchModel)
        {
            var query = _context.Profiles.Select(x => new ProfileViewModel
            {
                Id = x.Id,
                FullName = x.Account.FullName,
                City = x.City,
                CompanyName = x.CompanyName,
                Contry = x.Contry,
                Email = x.Email,
                PictureCoworker = x.PictureCoworker,
                Region = x.Region,
                Status = x.Status                
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.FullName.Contains(searchModel.Email));

            if (!string.IsNullOrWhiteSpace(searchModel.CompanyName))
                query = query.Where(x => x.CompanyName.Contains(searchModel.CompanyName));

            if (!string.IsNullOrWhiteSpace(searchModel.Region))
                query = query.Where(x => x.Region.Contains(searchModel.Region));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
