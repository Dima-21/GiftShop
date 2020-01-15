using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Price
    {
        public Price()
        {
            Goods = new HashSet<Goods>();
        }

        public int Id { get; set; }
        public decimal OrigPrice { get; set; }
        public decimal SpecPrice { get; set; }
        public byte PercentDisc { get; set; }
        public decimal SumDisc { get; set; }
        public DateTime ValidFrom { get; set; }

        public ICollection<Goods> Goods { get; set; }
    }
}
