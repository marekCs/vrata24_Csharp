namespace Vrata24.Core.Entities;

public class Product : BaseEntity
{
    public string? ProductName { get; set; }
    public string? ProductDescription { get; set; }
    public string? PictureUrl { get; set; }
    public int ProductHeight { get; set; }
    public int ProductDepth { get; set; }
    public int ProductWidth { get; set; }
    public int ProductWeight { get; set; }
    public decimal ProductPrice { get; set; }
    public ProductType? ProductType { get; set; }
    public int ProductTypeId { get; set; }
    public ProductBrand? ProductBrand { get; set; }
    public int ProductBrandId { get; set; }
}
