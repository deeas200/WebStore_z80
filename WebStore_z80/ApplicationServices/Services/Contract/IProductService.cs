namespace WebStore_z80.ApplicationServices.Services.Contract
{
    public interface IProductService
    {
        Task<List<Product>> SellectAllProduct();//SelectAll() GetAllproduct_Dto
        Task<Product> SelectProductById(Guid id);//SelectById() GetproductById_Dto
        void InsertProduct(Product product);//Insert() PostProduct_Dto
        void UpdateProduct(Product product);//Update() PotProduct_Dto
        void DeleteProduct(Guid id);//Delete() DeleteProduct_Dto


    }
}
