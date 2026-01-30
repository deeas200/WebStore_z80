namespace WebStore_z80.ApplicationServices.Dtos.ProductDtos
{
    public class ProductDetail
    {

        public Guid Id { get; set; }

        [Display(Name = "نام محصول")]
        //[Required(ErrorMessage = "نام محصول را باید وارد کنید")]
        public string ProductName { get; set; }

        [Display(Name = "توضیحات محصول")]
        //[Required(ErrorMessage = "توضیحات محصول را باید وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = "قیمت محصول")]
        // [Required(ErrorMessage = "قیمت محصول را باید وارد کنید")]
        public decimal UnitPrice { get; set; }
    }
}
