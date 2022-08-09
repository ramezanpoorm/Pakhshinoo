
namespace AccountManagement.Application.Contract.Profile
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Contry { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PictureCoworker { get; set; }
        public int Status { get; set; }
    }
}
