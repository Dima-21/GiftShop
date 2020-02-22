using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Goods
    {
        public Goods()
        {
            Charact = new HashSet<Charact>();
            GoodsImage = new HashSet<GoodsImage>();
            OrderGoods = new HashSet<OrderGoods>();
        }

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Descript { get; set; }
        public string ShortDescript { get; set; }
        public int GroupId { get; set; }
        public DateTime PublishData { get; set; }
        public bool IsHidden { get; set; }
        public short Amount { get; set; }
        public decimal Price { get; set; }

        public Group Group { get; set; }
        public ICollection<Charact> Charact { get; set; }
        public ICollection<GoodsImage> GoodsImage { get; set; }
        public ICollection<OrderGoods> OrderGoods { get; set; }
    }
}
