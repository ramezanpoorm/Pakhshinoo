
using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Setting
{
    public class EditSetting
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Instagram { get; set; }
        public string Telegram { get; set; }
        public string Address { get; set; }
        public string Banner1Title { get; set; }
        public string Banner1Des { get; set; }
        public IFormFile Banner1Pic { get; set; }
        public string Banner1Link { get; set; }
        public string Banner2Title { get; set; }
        public string Banner2Des { get; set; }
        public IFormFile Banner2Pic { get; set; }
        public string Banner2Link { get; set; }
        public string Banner3Title { get; set; }
        public string Banner3Des { get; set; }
        public IFormFile Banner3Pic { get; set; }
        public string Banner3Link { get; set; }
        public bool Percent9 { get; set; }
    }
}
