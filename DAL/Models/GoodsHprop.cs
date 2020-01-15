using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class GoodsHprop
    {
        public int GoodsId { get; set; }
        public int ProdId { get; set; }
        public short Amount { get; set; }

        public Goods Goods { get; set; }
        public Hproduct Prod { get; set; }
    }
}
