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
        #region [-SelectAll-]
        public async Task<IEnumerable<Product>> SelectAll()
        {
            try
            {
                return await _context.product.ToListAsync();
            }
            catch (Exception) { throw; }
        }
        #endregion
        #region [-SelectById-]
        public async Task<Product> SelectByIdAsync(Guid id)
        {
            Product p= await _context.product.SingleOrDefaultAsync(x => x.Id == id);
            if (p == null) { return null; }
            return p;
           // return await _context.product.FirstOrDefaultAsync(p => p.Id == id);
        }



        #endregion
        #region [-Update-]

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                var upProduct = await _context.Set<Product>().FindAsync(product.Id);


                if (upProduct == null)
                    return null;

                upProduct.ProductName = product.ProductName;
                upProduct.ProductDescription = product.ProductDescription;
                upProduct.UnitPrice = product.UnitPrice;

                await _context.SaveChangesAsync();
                return upProduct;

            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }


        #endregion
        #region [-Insert-]
        public Task Insert(Product product)
        {
            try
            {
                _context.Add(product);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region [-Delete-]
        public async Task<Product> DeleteAsync(Guid id)
        {
            var product = await _context.Set<Product>().FindAsync(id);
            if (product != null)
            {
                _context.Set<Product>().Remove(product);
                await _context.SaveChangesAsync();
            }
            return product; // برگرداندن شخص حذف‌شده یا null
        }

        //public Task<Product> SelectByIdAsync(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion



        //#region Insert
        //public async Task InsertProduct(Product product)//return void
        //{
        //    try
        //    {
        //        _context.product.Add(product);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        //#endregion

        //#region Delete
        //public async Task DeleteProduct(Guid id)//return void
        //{
        //    try
        //    {
        //        var product = _context.product.FirstOrDefault(x => x.Id == id);
        //        if (product != null)
        //        {
        //            _context.product.Remove(product);
        //            _context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}
        //#endregion

        //#region Select

        //public IEnumerable<Product> SellectAllProduct()
        //{
        //    return _context.product.ToList();
        //}




        //public Product SelectProductById(Guid id)
        //{
        //    try
        //    {
        //        var product =_context.product.FirstOrDefault(x => x.Id == id);

        //        return product;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //#endregion

        //#region Update
        //public void UpdateProduct(Product product)
        //{
        //    _context.product.Update(product);
        //    _context.SaveChanges(true);
        //}
        //#endregion


        //*************************
        //#region [-Private Field-]
        //private readonly ProjectDbContext _context;
        //#endregion
        //#region [-Ctor-]
        //public ProductRepository(ProjectDbContext context)
        //{
        //    _context = context;
        //}

        //#endregion




    }
}
