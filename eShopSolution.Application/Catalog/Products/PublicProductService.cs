using eShopSolution.Application.Catalog.Products.Dtos.Manage;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.Application.Catalog.Products.Dtos;
using eShopSolution.Application.Common;
using eShopSolution.Application.Catalog.Products.Dtos.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog
{
    public class PublicProductService : IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> IPublicProductService.GetListByCategoryIdPageing(GetPublicProductPagingRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
