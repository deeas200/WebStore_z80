using System.Collections;

namespace WebStore_z80.Models.Services.Contracts
{
    public interface IProductRepository
    {
        //IEnumerable<Product> SellectAllProduct();//SelectAll()
        //Product SelectProductById(Guid id);//SelectById()
        //Task InsertProduct(Product product);//Insert()
        //void UpdateProduct(Product product);//Update()
        //Task DeleteProduct(Guid id);//Delete()


        #region [-SelectAll-]
        Task<IEnumerable<Product>> SelectAll();

        #endregion
        #region [-SelectById-]
        Task<Product> SelectByIdAsync(Guid id);

        #endregion
        #region [-Insert-]
        Task Insert(Product product);

        #endregion
        #region [-Delete-]
        Task<Product> DeleteAsync(Guid id);
        #endregion
        #region [-Update-]
        Task<Product> UpdateAsync(Product product);

        #endregion
    }
}
