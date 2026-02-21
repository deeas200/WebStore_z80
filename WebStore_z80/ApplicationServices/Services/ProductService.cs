using WebStore_z80.ApplicationServices.Dtos.ProductDtos;
using WebStore_z80.ApplicationServices.Services.Contract;
using WebStore_z80.Models.Services.Contracts;

namespace WebStore_z80.ApplicationServices.Services
{
    public class ProductService : IProductService
    {

        #region [-Private Field-]
        private readonly IProductRepository _productRepository;

        #endregion
        #region [-Ctor-]
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion
        #region [-Post-]
        public Task PostAsync(PostProductDto postProductDto)
        {
            var product = new Product()
            {
                Id = postProductDto.Id,
                ProductName = postProductDto.ProductName,
                UnitPrice = postProductDto.UnitPrice,
                ProductDescription = postProductDto.ProductDescription,
            };
            return _productRepository.Insert(product);

        }

        #endregion
        #region [-GetAll-]
        public async Task<List<GetProductDto>> GetAll()
        {
            var product = await _productRepository.SelectAll();
            if (product == null || !product.Any())
            {
                return new List<GetProductDto>();
            }

            var productList = new List<GetProductDto>();
            foreach (var item in product)
            {
                var productDto = new GetProductDto();
                {
                    productDto.Id = item.Id;
                    productDto.ProductName = item.ProductName;
                    productDto.UnitPrice = item.UnitPrice;
                    productDto.ProductDescription = item.ProductDescription;
                }
                productList.Add(productDto);
            }
            return productList;

        }

        #endregion
        #region [-GetById-]
        public async Task<GetByIdProductDto> GetProductByIdAsync(Guid id)
        {
            var getProduct = await _productRepository.SelectByIdAsync(id);
            if (getProduct == null)
            {
                return null;
            }
            var getByIdProductDto = new GetByIdProductDto();
            getByIdProductDto.Id = getProduct.Id;
            getByIdProductDto.ProductName = getProduct.ProductName;
            getByIdProductDto.ProductDescription = getProduct.ProductDescription;
            getByIdProductDto.UnitPrice = getProduct.UnitPrice;
            return getByIdProductDto;

        }


        #endregion   
        #region [-Delete-]
        public async Task<DeleteProductDto> DeleteAsync(Guid id)
        {
            var product = await _productRepository.DeleteAsync(id); // حذف واقعی انجام می‌شود
            if (product == null)
                return null;

            return new DeleteProductDto
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                UnitPrice = product.UnitPrice,
            };
        }

        #endregion
        #region [-Put-]
        public Task PutAsync(PutProductDto putProductDto)
        {
            var product = new Product();
            product.Id = putProductDto.Id;
            product.ProductName = putProductDto.ProductName;
            product.UnitPrice = putProductDto.UnitPrice;
            product.ProductDescription = putProductDto.ProductDescription;


            return _productRepository.UpdateAsync(product);
        }

        #endregion






        //#region Privet Fields

        //private readonly IProductRepository _productRepository;

        //#endregion

        //#region Constructor

        //public ProductService(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}
        //#endregion
        //public void DeleteProduct(Guid id)
        //{
        //    _productRepository.DeleteProduct(id);

        //}



        //public void InsertProduct(ProductCreate product)
        //{
        //    var newproduct = new Product();
        //    newproduct.ProductName = product.ProductName;
        //    newproduct.ProductDescription = product.ProductDescription;
        //    newproduct.UnitPrice = product.UnitPrice;
        //    _productRepository.InsertProduct(newproduct);
        //}

        //public ProductDetail SelectProductById(Guid id)
        //{
        //    var product=  _productRepository.SelectProductById(id);
        //    if (product == null)
        //    {
        //        return null;
        //    }
        //    var productDetail = new ProductDetail();
        //    productDetail.Id = product.Id;
        //    productDetail.ProductName = product.ProductName;
        //    productDetail.ProductDescription = product.ProductDescription;
        //    productDetail.UnitPrice = product.UnitPrice;
        //    return productDetail;
        //}


        //public async Task<List<ProductList>> SellectAllProduct()
        //{

        //    var productsr = await Task.FromResult(_productRepository.SellectAllProduct());

        //    if (productsr == null)
        //    {
        //        var p = new List<ProductList>();
        //        return p;
        //    }
        //    var productsList = new List<ProductList>();
        //    foreach (var product in productsr)
        //    {
        //        var productList = new ProductList
        //        {
        //            Id = product.Id,
        //            ProductName = product.ProductName,
        //            ProductDescription = product.ProductDescription,
        //            UnitPrice = product.UnitPrice,
        //        };
        //        productsList.Add(productList);
        //    }
        //    return productsList;
        //}


        //public void UpdateProduct(ProductUpdate productUpdate)
        //{
        //    var product = new Product();
        //    product.ProductName = productUpdate.ProductName;
        //    product.ProductDescription = productUpdate.ProductDescription;
        //    product.UnitPrice = productUpdate.UnitPrice;
        //    product.Id = productUpdate.Id;
        //    _productRepository.UpdateProduct(product);
        //}


    }
}
