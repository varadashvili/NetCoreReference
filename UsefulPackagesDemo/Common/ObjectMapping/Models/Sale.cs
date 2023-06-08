namespace UsefulPackagesDemo.Common.ObjectMapping.Models;

public class Sale
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public decimal SalePrice { get; set; }

    public DateTime SaleDate { get; set; }
}
