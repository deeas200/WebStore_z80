using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using WebStore_z80.Models.DBContext;
using WebStore_z80.Models.Services.Contracts;

namespace WebStore_z80.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Privete Fields

        private readonly StoreContext _context;

        #endregion
        #region Constructor

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        #endregion

        public async Task InsertProduct(Product product)//return void
        {
            throw new NotImplementedException();
        }

       public async Task DeleteProduct(Guid id)//return void
        {
            throw new NotImplementedException();
        }

       public async Task<List<Product>> SellectAllProduct()
        {
            try
            {
                return await _context.product.ToListAsync();
                
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public async Task<Product> SelectProductById(Guid id)
        {
            throw new NotImplementedException();
        }

         public async Task UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

       
    }
}
