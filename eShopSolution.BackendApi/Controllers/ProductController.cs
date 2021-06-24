using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModels.Catalog.Products.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;
        public ProductController(IPublicProductService publicProductService, 
            IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }
        // done
        [HttpPost(nameof(GetAllProductsByLanguageId))]
        public  async Task<IActionResult> GetAllProductsByLanguageId(string languageId)
        {
            var products = await _publicProductService.GetAll(languageId);
            return Ok(products);
        }
        //done
        [HttpPost(nameof(GetListByCategoryIdPageing))]
        public async Task<IActionResult> GetListByCategoryIdPageing([FromBody]GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetListByCategoryIdPageing(request);

            return Ok(products);
        }
        //done
        [HttpPost(nameof(GetProductByIdAndLanguageId))]
        public async Task<IActionResult> GetProductByIdAndLanguageId(int id, string languageId)
        {
            var product = await _manageProductService.GetById(id, languageId);
            if (product == null)
            {
                return BadRequest("can not find product id");
            }
            return Ok(product);
        }
        // xong chức năng
        [HttpPost(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = _manageProductService.GetById(productId, request.LanguageId);

            return Created(nameof(GetProductByIdAndLanguageId), product);
        }
        
    }
}
