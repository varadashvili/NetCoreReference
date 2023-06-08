using Mapster;

using MapsterMapper;

using Microsoft.AspNetCore.Mvc;

using UsefulPackagesDemo.Common.ObjectMapping.Contracts;
using UsefulPackagesDemo.Common.ObjectMapping.Dtos;
using UsefulPackagesDemo.Common.ObjectMapping.Models;

namespace UsefulPackagesDemo.Common.ObjectMapping.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MapsterController : ControllerBase
{
    private readonly IMapper _mapper;

    public MapsterController(IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetSale()
    {
        await Task.CompletedTask;

        var sale = getSaleFromDb();
        var product = getProductFromDb();

        var saleDto = _mapper.Map<SaleDto>((product, sale));

        var saleResponse = saleDto.Adapt<SaleResponse>();

        return Ok(saleResponse);
    }

    private Sale getSaleFromDb()
    {
        return new Sale
        {
            SaleId = 1,
            ProductId = 123,
            SalePrice = 89.99m,
            SaleDate = DateTime.Now
        };
    }

    private Product getProductFromDb()
    {
        return new Product
        {
            ProductId = 11,
            Name = "Example Product",
            Price = 99.99m,
            Description = "This is an example product description.",
            IsAvailable = true,
            CreatedDate = DateTime.Now.AddYears(-1),
        };
    }
}
