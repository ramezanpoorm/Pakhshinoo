using _0_Framework.Infrastructure;
using _01_PakhshinoQuery.Contract;
using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Car;
using _01_PakhshinoQuery.Contract.Company;
using _01_PakhshinoQuery.Contract.Oredr;
using _01_PakhshinoQuery.Contract.Product;
using _01_PakhshinoQuery.Contract.ProductCategory;
using _01_PakhshinoQuery.Contract.Slide;
using _01_PakhshinoQuery.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Brand;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Application.Contracts.CarProduct;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductCompany;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Setting;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.BrandAgg;
using ShopManagement.Domain.CarAgg;
using ShopManagement.Domain.CarProductAgg;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.CompanyProductAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.Services;
using ShopManagement.Domain.SettingAgg;
using ShopManagement.Domain.SliderAgg;
using ShopManagement.Infrastructure.InventoryAcl;
using ShopManagement.InfraStructure.EFCore;
using ShopManagement.InfraStructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBoostrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            service.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            service.AddTransient<IProductApplication, ProductApplication>();
            service.AddTransient<IProductRepository, ProductRepository>();

            service.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            service.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            service.AddTransient<ISlideApplication, SlideApplication>();
            service.AddTransient<ISlideRepository, SlideRepository>();

            service.AddTransient<IOrderApplication, OrderApplication>();
            service.AddTransient<IOrderRepository, OrderRepository>();

            service.AddTransient<ICarApplication, CarApplication>();
            service.AddTransient<ICarRepository, CarRepository>();

            service.AddTransient<IBrandApplication, BrandApplication>();
            service.AddTransient<IBrandRepository, BrandRepository>();

            service.AddTransient<ISettingApplication, SettingApplication>();
            service.AddTransient<ISettingRepository, SettingRepository>();

            service.AddTransient<ICompanyApplication, CompanyApplication>();
            service.AddTransient<ICompanyRepository, CompanyRepository>();

            service.AddTransient<IProductCompanyApplication, ProductCompanyApplicatipon>();
            service.AddTransient<ICompanyProductRepository, ProductCompanyRepository>();

            service.AddTransient<ICarProductApplication, CarProductApplication>();
            service.AddTransient<ICarProductRepository, CarProductRepository>();

            service.AddTransient<ISlideQuery, SlideQuery>();
            service.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            service.AddTransient<IProductQuery, ProductQuery>();
            service.AddTransient<IBrandQuery, BrandQuery>();
            service.AddTransient<ICarQuery, CarQuery>();
            service.AddTransient<IOrderQuery, OrderQuery>();
            service.AddTransient<ICompanyQuery, CompanyQuery>();
            service.AddTransient<ICartCalculatorService, CartCalculatorService>();
            service.AddSingleton<ICartService, CartService>();


            service.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            service.AddTransient<IShopInventoryAcl, ShopInventoryAcl>();

            service.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
