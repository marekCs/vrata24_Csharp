namespace Vrata24.Api.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string PictureUrl { get; set; }
        public int ProductHeight { get; set; }
        public int ProductDepth { get; set; }
        public int ProductWidth { get; set; }
        public int ProductWeight { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductType { get; set; }
        public string ProductBrand { get; set; }
    }
}