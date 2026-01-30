using System.Collections;

namespace WebStore_z80.Models.Services.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> SellectAllProduct();//SelectAll()
        Product SelectProductById(Guid id);//SelectById()
        Task InsertProduct(Product product);//Insert()
        void UpdateProduct(Product product);//Update()
        Task DeleteProduct(Guid id);//Delete()
    }
}
