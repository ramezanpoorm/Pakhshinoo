
using _0_Framework.Domain;

namespace ShopManagement.Domain.SettingAgg
{
    public class Setting : EntityBase
    {
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Instagram { get; private set; }
        public string Telegram { get; private set; }
        public string Address { get; private set; }
        public string Banner1Title { get; private set; }
        public string Banner1Des { get; private set; }
        public string Banner1Pic { get; private set; }
        public string Banner1Link { get; private set; }
        public string Banner2Title { get; private set; }
        public string Banner2Des { get; private set; }
        public string Banner2Pic { get; private set; }
        public string Banner2Link { get; private set; }
        public string Banner3Title { get; private set; }
        public string Banner3Des { get; private set; }
        public string Banner3Pic { get; private set; }
        public string Banner3Link { get; private set; }
        public bool Percent9 { get; private set; }

        public void Edit(string phoneNumber, string emailAddress, string instagram, string telegram, string address, string banner1Title, string banner1Des, string banner1Pic, string banner1Link, string banner2Title, string banner2Des, string banner2Pic, string banner2Link, string banner3Title, string banner3Des, string banner3Pic, string banner3Link, bool percent9)
        {
            if (!string.IsNullOrWhiteSpace(banner1Pic))
                Banner1Pic = banner1Pic;
            if (!string.IsNullOrWhiteSpace(banner2Pic))
                Banner2Pic = banner2Pic;
            if (!string.IsNullOrWhiteSpace(banner3Pic))
                Banner3Pic = banner3Pic;

            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Instagram = instagram;
            Telegram = telegram;
            Address = address;
            Percent9 = percent9;
            Banner1Title = banner1Title;
            Banner1Des = banner1Des;
            Banner1Link = banner1Link;
            Banner2Title = banner2Title;
            Banner2Des = banner2Des;
            Banner2Link = banner2Link;
            Banner3Title = banner3Title;
            Banner3Des = banner3Des;
            Banner3Link = banner3Link;
        }
    }

}
