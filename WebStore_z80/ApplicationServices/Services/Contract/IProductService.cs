namespace WebStore_z80.ApplicationServices.Services.Contract
{
    public interface IProductService
    {
        Task<List<ProductList>> SellectAllProduct();//SelectAll() GetAllproduct_Dto
        
        ProductDetail SelectProductById(Guid id);//SelectById() GetproductById_Dto
        void InsertProduct(ProductCreate product);//Insert() PostProduct_Dto
        void UpdateProduct(ProductUpdate product);//Update() PotProduct_Dto
        void DeleteProduct(Guid id);//Delete() DeleteProduct_Dto


    }
}
