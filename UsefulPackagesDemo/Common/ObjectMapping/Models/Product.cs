namespace UsefulPackagesDemo.Common.ObjectMapping.Models;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime CreatedDate { get; set; }
}
