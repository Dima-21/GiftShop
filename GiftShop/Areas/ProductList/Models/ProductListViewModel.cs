﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Models;

namespace GiftShop.Areas.ProductList.Models
{
    public class ProductListViewModel
    {
        public List<GoodsDTO> Goods { get; set; }
    }
}
