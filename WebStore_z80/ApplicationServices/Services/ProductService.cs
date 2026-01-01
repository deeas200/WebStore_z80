using WebStore_z80.ApplicationServices.Dtos.ProductDtos;
using WebStore_z80.ApplicationServices.Services.Contract;
using WebStore_z80.Models.Services.Contracts;

namespace WebStore_z80.ApplicationServices.Services
{
    public class ProductService : IProductService
    {
        #region Privet Fields

        private readonly IProductRepository _productRepository;

        #endregion

        #region Constructor

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        public void DeleteProduct(Guid id)
        {
            _productRepository.DeleteProduct(id);
            
        }

        public void InsertProduct(Product productCreate)
        {
            var newproduct = new Product();
            newproduct.ProductName = productCreate.ProductName;
            newproduct.ProductDescription = productCreate.ProductDescription;
            newproduct.UnitPrice = productCreate.UnitPrice;
            _productRepository.InsertProduct(newproduct);
        }

        public async Task<Product> SelectProductById(Guid id)
        {
            return await _productRepository.SelectProductById(id);
        }

        public async Task< List<Product>> SellectAllProduct()
        {
            return await _productRepository.SellectAllProduct();
           
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}
