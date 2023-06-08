namespace UsefulPackagesDemo.Common.ObjectMapping.Dtos;

public record SaleDto(
    int SaleId,
    ProductDto Product,
    decimal SalePrice,
    DateTime SaleDate);
