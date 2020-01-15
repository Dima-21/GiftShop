using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class OrderGoods
    {
        public int OrderId { get; set; }
        public int GoodsId { get; set; }
        public int Price { get; set; }
        public short Amount { get; set; }

        public Goods Goods { get; set; }
        public Order Order { get; set; }
    }
}
