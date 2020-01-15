using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class GoodsImage
    {
        public int GoodsId { get; set; }
        public int ImageId { get; set; }

        public Goods Goods { get; set; }
        public Image Image { get; set; }
    }
}
