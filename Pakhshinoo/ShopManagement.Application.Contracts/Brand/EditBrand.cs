﻿namespace ShopManagement.Application.Contracts.Brand
{
    public class EditBrand : CreateBrand
    {
        public long Id { get; set; }
        public string PictureDB { get; set; }
    }
}
