namespace UsefulPackagesDemo.Common.ObjectMapping.Contracts;

public record ProductResponse(
    string Name,
    decimal Price,
    string Description,
    bool IsAvailable,
    string FormattedPrice,
    DateTime CreatedDate);

