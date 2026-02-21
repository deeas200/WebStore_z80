namespace WebStore_z80.ApplicationServices.Services.Contract
{
    public interface IProductService
    {
        //Task<List<GetProductDto>> SellectAllProduct();//SelectAll() GetAllproduct_Dto

        //GetByIdProductDto SelectProductById(Guid id);//SelectById() GetproductById_Dto
        //void InsertProduct(PostProductDto product);//Insert() PostProduct_Dto
        //void UpdateProduct(PutProductDto product);//Update() PotProduct_Dto
        //void DeleteProduct(Guid id);//Delete() DeleteProduct_Dto
       
            #region [-Post-]
            Task PostAsync(PostProductDto postProductDto);

            #endregion
            #region [-GetAll-]
            Task<List<GetProductDto>> GetAll();

            #endregion
            #region [-GetById-]
            Task<GetByIdProductDto> GetProductByIdAsync(Guid id);

            #endregion
            #region [-Delete-]
            Task<DeleteProductDto> DeleteAsync(Guid id);

            #endregion
            #region [-Put-]
            Task PutAsync(PutProductDto putProductDto);
            #endregion


        }
    }

