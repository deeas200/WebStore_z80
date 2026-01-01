namespace WebStore_z80.Models.Services.Contracts
{
    public interface IProductRepository
    {
       Task<List<Product>> SellectAllProduct();//SelectAll()
        Task<Product> SelectProductById(Guid id);//SelectById()
        Task InsertProduct(Product product);//Insert()
        Task UpdateProduct(Product product);//Update()
        Task DeleteProduct(Guid id);//Delete()
    }
}
