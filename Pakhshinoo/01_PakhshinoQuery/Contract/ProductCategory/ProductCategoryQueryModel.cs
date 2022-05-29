using _01_PakhshinoQuery.Contract.Paging;
using _01_PakhshinoQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.ProductCategory
{
    public class ProductCategoryQueryModel : BasePaging
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public long BrandId { get; set; }
        public List<ProductQueryModel> Products { get; set; }
        public double DoublePrice { get; set; }
        public int StartPrice { get; set; }
        public int EndPrice { get; set; }
        //public ProductQueryModel SetPaging(BasePaging paging)
        //{
        //    this.PageId = paging.PageId;
        //    this.PageCount = paging.PageCount;
        //    this.StartPage = paging.StartPage;
        //    this.EndPage = paging.EndPage;
        //    this.TakeEntity = paging.TakeEntity;
        //    this.SkipEntity = paging.SkipEntity;
        //    this.ActivePage = paging.ActivePage;
        //    return this;
        //}

        //public ProductQueryModel SetProducts(List<ProductQueryModel> products)
        //{
        //    this.Products = products;
        //    return this;
        //}


    }
}
