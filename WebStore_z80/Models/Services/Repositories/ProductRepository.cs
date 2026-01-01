using Microsoft.AspNetCore.Http.HttpResults;
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

        #region Insert
        public async Task InsertProduct(Product product)//return void
        {
            try
            {
                _context.product.Add(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Delete
        public async Task DeleteProduct(Guid id)//return void
        {
            try
            {
                var product = await _context.product.FirstOrDefaultAsync(x => x.Id == id);
                if (product != null)
                {
                    _context.product.Remove(product);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Select
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
            try
            {
                var product = await _context.product.FirstOrDefaultAsync(x => x.Id == id);

                return product;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Update
        public async Task UpdateProduct(Product product)
        {
            _context.product.Update(product);
            _context.SaveChanges(true);
        }
        #endregion



    }
}
