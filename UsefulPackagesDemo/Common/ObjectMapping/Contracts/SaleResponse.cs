namespace UsefulPackagesDemo.Common.ObjectMapping.Contracts;

public record SaleResponse(
    ProductResponse Product,
    decimal SalePrice,
    DateTime SaleDate);