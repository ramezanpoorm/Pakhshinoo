using _01_PakhshinoQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public List<ProductQueryModel> Products { get; set; }
    }
}
