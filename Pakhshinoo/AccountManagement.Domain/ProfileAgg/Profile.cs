
using _0_Framework.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.ProfileAgg
{
    public class Profile : EntityBase
    {
        public long AccountId { get; private set; }
        public Account Account { get; private set; }
        public string CompanyName { get; private set; }
        public string Contry { get; private set; }
        public string Region { get; private set; }
        public string City { get; private set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string Email { get; private set; }
        public bool Coworker { get; private set; }
        public string PictureCoworker { get; private set; }
        public int Status { get; private set; }

        public Profile(long accountId, string companyName, string contry, string region, string city, string address, string postalCode, string email, bool coworker, string pictureCoworker)
        {
            AccountId = accountId;
            CompanyName = companyName;
            Contry = contry;
            Region = region;
            City = city;
            Address = address;
            PostalCode = postalCode;
            Email = email;
            Coworker = coworker;
            PictureCoworker = pictureCoworker;
            Status = 1;
        }

        public void Edit(string companyName, string contry, string region, string city, string address, string postalCode, string email, bool coworker, string pictureCoworker)
        {
            CompanyName = companyName;
            Contry = contry;
            Region = region;
            City = city;
            Address = address;
            PostalCode = postalCode;
            Email = email;
            Coworker = coworker;

            if (!string.IsNullOrWhiteSpace(pictureCoworker))
                PictureCoworker = pictureCoworker;

        }
    }
}
