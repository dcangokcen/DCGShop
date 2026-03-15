using AutoMapper;
using DCGShop.Catalog.Dtos.CategoryDtos;
using DCGShop.Catalog.Dtos.FeatureSliderDtos;
using DCGShop.Catalog.Dtos.ProductDetailDtos;
using DCGShop.Catalog.Dtos.ProductDtos;
using DCGShop.Catalog.Dtos.ProductImageDtos;
using DCGShop.Catalog.Entities;

namespace DCGShop.Catalog.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<Category,ResultCategoryDto>().ReverseMap();
			CreateMap<Category,CreateCategoryDto>().ReverseMap();
			CreateMap<Category,UpdateCategoryDto>().ReverseMap();
			CreateMap<Category,GetByIdCategoryDto>().ReverseMap();

			CreateMap<Product,ResultProductDto>().ReverseMap();
			CreateMap<Product,CreateProductDto>().ReverseMap();
			CreateMap<Product,UpdateProductDto>().ReverseMap();
			CreateMap<Product,GetByIdProductDto>().ReverseMap();

			CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
			CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

			CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
			CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
			CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

			CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
			CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

			CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();
		}
	}
}
