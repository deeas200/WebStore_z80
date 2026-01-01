namespace WebStore_z80.ApplicationServices.Dtos.ProductDtos
{
    public class ProductUpdate
    {
        public Guid Id { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
