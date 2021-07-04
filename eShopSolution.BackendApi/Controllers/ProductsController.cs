using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.ProductImages;
using eShopSolution.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //done
        [HttpPost(nameof(GetListByCategoryId))]
        public async Task<IActionResult> GetListByCategoryId(string languageId, GetPublicProductPagingRequest request)
        {
            var products = await _productService.GetListByCategoryIdPageing(languageId, request);
            return Ok(products);
        }
        //done
        [HttpPost(nameof(GetProductByIdAndLanguageId))]
        public async Task<IActionResult> GetProductByIdAndLanguageId(int id, string languageId)
        {
            var product = await _productService.GetById(id, languageId);
            if (product == null)
            {
                return BadRequest("can not find product");
            }
            return Ok(product);
        }
        // xong chức năng
        [HttpPost(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            if(ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _productService.GetById(productId, request.LanguageId);

            return Ok(product);
        }
        //update product
        [HttpPost(nameof(UpdateProduct))]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdateRequest request)
        {
            var affectedResult = await _productService.Update(request);
            if (affectedResult == 0)
            {
                return BadRequest();
            }

            return  Ok();
        }
        //delete product
        [HttpPost(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var affectedResult = await _productService.Delete(productId);
            if (affectedResult == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        //update price
        // HttpPatch?
        [HttpPatch(nameof(UpdatePriceProduct))]
        public async Task<IActionResult> UpdatePriceProduct(int productId, decimal newPrice)
        {
            var isSuccessful = await _productService.UpdatePrice(productId, newPrice);
            if (isSuccessful == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPost(nameof(CreateImage))]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _productService.AddImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }
            var image = await _productService.GetImageById(imageId);
            return Ok(image);
        }
        [HttpPost(nameof(UpdateImage))]
        public async Task<IActionResult> UpdateImage(int productId, [FromForm] ProductImageUpdateRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            var isSuccess = await _productService.UpdateImage(productId, request);
            if (isSuccess == 0)
            {
                return BadRequest();
            }
            var productImage = await _productService.GetImageById(productId);
            return Ok(productImage);
        }
        [HttpPost(nameof(RemoveImage))]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();

            return Ok();
        }
        [HttpGet(nameof(GetImageById))]
        public async Task<IActionResult> GetImageById(int productId, int imageId)
        {
            var image = await _productService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find product");
            return Ok(image);
        }
    }
}
