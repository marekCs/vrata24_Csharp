namespace Vrata24.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = null!;
    public string ProductDescription { get; set; } = null!;
    public int ProductHeight { get; set; }
    public int ProductLength { get; set; }
    public int ProductWidth { get; set; }
    public int ProductWeight { get; set; }
    public double ProductPrice { get; set; }
}
