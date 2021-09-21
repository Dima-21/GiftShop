using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public partial class CartItem
    {
        public long? Id { get; set; }
        public string ShopCartId { get; set; }
        public short Amount { get; set; }
        public int GoodsId{ get; set; }
        public Goods Goods{ get; set; }
    }
}
