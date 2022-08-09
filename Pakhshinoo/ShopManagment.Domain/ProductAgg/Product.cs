using _0_Framework.Domain;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CarAgg;
using ShopManagement.Domain.CarProductAgg;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.CompanyProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public long CategoryId { get; private set; }
        //public long CarId { get; private set; }
        public long BrandId { get; private set; }
        //public long CompanyId { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public bool IsSpecial { get; private set; }
        public int VisitCount { get; private set; }
        public ProductCategory Category { get; private set; }        
        public Brand Brand { get; private set; }
        public List<CarProduct> CarProducts { get; private set; }
        public List<CompanyProduct> CompanyProducts { get; private set; }
        public List<ProductPicture> ProductPictures { get; private set; }

        public double UnitPrice { get; private set; }

        public Product(string name, string code, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription, long brandId)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsSpecial = false;
            VisitCount = 0;
            BrandId = brandId;
        }

        public void Edit(string name, string code, string shortDescription, string description, string picture, string pictureAlt, string pictureTitle, long categoryId, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Code = code;
            ShortDescription = shortDescription;
            Description = description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void Special()
        {
            IsSpecial = true;
        }

        public void NotSpecial()
        {
            IsSpecial = false;
        }

        public void VisitIncrease()
        {
            VisitCount = VisitCount + 1;
        }

    }
}
