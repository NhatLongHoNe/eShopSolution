﻿using eShopSolution.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Application.Catalog.Products.Dtos.Public
{
    public class GetPublicProductPagingRequest:PagingRequestBase
    {
        public int CategoryId { get; set; }
    }
}