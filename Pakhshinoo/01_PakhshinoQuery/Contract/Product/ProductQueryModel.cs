
using _01_PakhshinoQuery.Contract.Comment;
using _01_PakhshinoQuery.Contract.Paging;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Product
{
    public class ProductQueryModel :BasePaging
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public double DoublePrice { get; set; }
        public string PriceWithDiscountForShow { get; set; }
        public double PriceWithDiscountForCart { get; set; }
        public int DiscountRate { get; set; }
        public string Category { get; set; }
        public string Slug { get; set; }
        public bool IsSpecial { get; set; }
        public bool HasDiscount { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsStock { get; set; }
        public long BrandId { get; set; }
        public long CarId { get; set; }
        public long CompanyId { get; set; }
        public string Brand { get; set; }
        public double StartPrice { get; set; }
        public double EndPrice { get; set; }
        public string EndDate { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
        public List<CommentQueryModel> Comments { get; set; }
    }
}
