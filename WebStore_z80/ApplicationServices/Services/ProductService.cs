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

       

        public void InsertProduct(ProductCreate product)
        {
            var newproduct = new Product();
            newproduct.ProductName = product.ProductName;
            newproduct.ProductDescription = product.ProductDescription;
            newproduct.UnitPrice = product.UnitPrice;
            _productRepository.InsertProduct(newproduct);
        }

        public ProductDetail SelectProductById(Guid id)
        {
            var product=  _productRepository.SelectProductById(id);
            if (product == null)
            {
                return null;
            }
            var productDetail = new ProductDetail();
            productDetail.Id = product.Id;
            productDetail.ProductName = product.ProductName;
            productDetail.ProductDescription = product.ProductDescription;
            productDetail.UnitPrice = product.UnitPrice;
            return productDetail;
        }


        public async Task<List<ProductList>> SellectAllProduct()
        {

            var productsr = await Task.FromResult(_productRepository.SellectAllProduct());
            
            if (productsr == null)
            {
                var p = new List<ProductList>();
                return p;
            }
            var productsList = new List<ProductList>();
            foreach (var product in productsr)
            {
                var productList = new ProductList
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    UnitPrice = product.UnitPrice,
                };
                productsList.Add(productList);
            }
            return productsList;
        }


        public void UpdateProduct(ProductUpdate productUpdate)
        {
            var product = new Product();
            product.ProductName = productUpdate.ProductName;
            product.ProductDescription = productUpdate.ProductDescription;
            product.UnitPrice = productUpdate.UnitPrice;
            product.Id = productUpdate.Id;
            _productRepository.UpdateProduct(product);
        }

        
    }
}
