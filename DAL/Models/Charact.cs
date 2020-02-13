using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Charact
    {
        public int GoodsId { get; set; }
        public int PropId { get; set; }
        public string Value { get; set; }

        public Goods Goods { get; set; }
        public Property Prop { get; set; }
    }
}
