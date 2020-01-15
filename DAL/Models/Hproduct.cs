using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Hproduct
    {
        public Hproduct()
        {
            GoodsHprop = new HashSet<GoodsHprop>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Weight { get; set; }
        public double? Length { get; set; }
        public double? Width { get; set; }
        public double? Height { get; set; }
        public int? ValInBox { get; set; }
        public int? ImageId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime? DataEnd { get; set; }

        public ICollection<GoodsHprop> GoodsHprop { get; set; }
    }
}
