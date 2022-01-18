﻿
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OpretaionResult Create(CreateProductCategory command);
        OpretaionResult Edit(EditProductCategory command);
        EditProductCategory GetDetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
