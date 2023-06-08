using Mapster;

using UsefulPackagesDemo.Common.ObjectMapping.Contracts;
using UsefulPackagesDemo.Common.ObjectMapping.Dtos;
using UsefulPackagesDemo.Common.ObjectMapping.Models;

namespace UsefulPackagesDemo.Common.ObjectMapping.Mapster;

public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductDto>()
            .Map(dest => dest.FormattedPrice, src => $"Product price: {src.Price.ToString("C")}");

        config.NewConfig<(Product product, Sale sale), SaleDto>()
            .Map(dest => dest.Product, src => src.product.Adapt<ProductDto>())
            .Map(dest => dest, src => src.sale);

        config.ForType<(Product product, Sale sale), SaleDto>()
            .BeforeMapping(dest => { })
            .AfterMapping(dest => { });

        config.ForDestinationType<SaleResponse>()
            .AfterMapping(dest => { });
    }
}
