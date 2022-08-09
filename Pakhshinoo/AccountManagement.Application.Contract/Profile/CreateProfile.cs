
using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Profile
{
    public class CreateProfile
    {
        public long AccountId { get; set; }
        public string CompanyName { get; set; }
        public string Contry { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public bool Coworker { get; set; }
        public IFormFile PictureCoworker { get; set; }
    }
}
