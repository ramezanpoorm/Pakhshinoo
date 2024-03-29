﻿

using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.BrandAgg
{
    public class Brand : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string Url { get; private set; }
        public List<Product> Products { get; private set; }
        public bool IsRemoved { get; set; }
        public Brand()
        {
            Products = new List<Product>();
        }

        public Brand(string name, string description, string picture, string url)
        {
            Name = name;
            Description = description;
            Picture = picture;
            Url = url;
            IsRemoved = false;
        }

        public void Edit(string name, string description, string picture, string url)
        {
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            Name = name;
            Description = description;
            //Picture = picture;
            Url = url;
        }

        public void Removed()
        {
            IsRemoved = true;
        }
        public void NotRemoved()
        {
            IsRemoved = false;
        }
    }
}
