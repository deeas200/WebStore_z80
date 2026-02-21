using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStore_z80.ApplicationServices.Dtos.ProductDtos;

namespace WebStore_z80.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(PostProductDto postProductDto)
        {
            if (ModelState.IsValid)
            {
                _productService.PostAsync(postProductDto);
                //_productService.AddProductAsync(productCreate);
                return RedirectToAction(nameof(ProductList));
            }
            return View(postProductDto);
        }

        public async Task<IActionResult> ProductList()
        {
            return View(await _productService.GetAll());
        }

        public IActionResult ProductDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product = _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/ProductUpdate/5
        public async Task<IActionResult> ProductUpdate(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var productDetail =await _productService.GetProductByIdAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            var productUpdate = new PutProductDto
            {
                Id = productDetail.Id,
                ProductName = productDetail.ProductName,
                ProductDescription = productDetail.ProductDescription,
                UnitPrice = productDetail.UnitPrice
            };
            return View(productUpdate);
        }

        // POST: Products/ProductUpdate/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductUpdate(Guid id, [Bind("Id,ProductName,ProductDescription,UnitPrice")] PutProductDto productUpdate)
        {
            if (id != productUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  await  _productService.PutAsync(productUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productUpdate.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ProductList));
            }
            return View(productUpdate);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> ProductDelete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product =await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var product = _productService.GetProductByIdAsync(id);
            if (product != null)
            {
                var productDelete = new DeleteProductDto();
                productDelete.Id = id;
                _productService.DeleteAsync(productDelete.Id);
            }
            return RedirectToAction(nameof(ProductList));
        }

        private bool ProductExists(Guid id)
        {
            return _productService.Equals(id) != null;
        }
    }
}
