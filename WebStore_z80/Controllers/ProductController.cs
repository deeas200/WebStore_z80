using Microsoft.AspNetCore.Mvc;
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
        public IActionResult ProductCreate(ProductCreate product)
        {
            if (ModelState.IsValid)
            {
                _productService.InsertProduct(product);
                //_productService.AddProductAsync(productCreate);
                return RedirectToAction(nameof(ProductList));
            }
            return View(product);
        }

        public async Task<IActionResult> ProductList()
        {
            return View(await _productService.SellectAllProduct());
        }

        public IActionResult ProductDetails(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var product = _productService.SelectProductById(id);
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

            var productDetail = _productService.SelectProductById(id);
            if (productDetail == null)
            {
                return NotFound();
            }
            var productUpdate = new ProductUpdate
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
        public IActionResult ProductUpdate(Guid id, [Bind("Id,ProductName,ProductDescription,UnitPrice")] ProductUpdate productUpdate)
        {
            if (id != productUpdate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _productService.UpdateProduct(productUpdate);
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

            var product = _productService.SelectProductById(id);
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
            var product = _productService.SelectProductById(id);
            if (product != null)
            {
                var productDelete = new ProductDelete();
                productDelete.Id = id;
                _productService.DeleteProduct(productDelete.Id);
            }
            return RedirectToAction(nameof(ProductList));
        }

        private bool ProductExists(Guid id)
        {
            return _productService.Equals(id) != null;
        }
    }
}
