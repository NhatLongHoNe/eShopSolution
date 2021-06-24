using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Catalog.Products.Dtos;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetListByCategoryIdPageing(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll(string productId);
    }
}
