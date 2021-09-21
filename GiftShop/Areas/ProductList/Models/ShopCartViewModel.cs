using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.ProductList.Models
{
    public class ShopCartViewModel
    {
        public List<CartGoodsDTO> Cart { get; set; }
    }
}
