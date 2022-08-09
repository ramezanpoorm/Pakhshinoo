
using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.Brand
{
    public class CreateBrand
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string Url { get; set; }
    }
}
