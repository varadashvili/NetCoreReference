namespace UsefulPackagesDemo.Common.ObjectMapping.Dtos;

public record ProductDto(
    int ProductId,
    string Name,
    decimal Price,
    string Description,
    bool IsAvailable,
    string FormattedPrice,
    DateTime CreatedDate);
