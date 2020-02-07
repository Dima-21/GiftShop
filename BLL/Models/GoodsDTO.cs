using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace BLL.Models
{
    public class GoodsDTO
    {

        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int PriceId { get; set; }
        public string Descript { get; set; }
        public string ShortDescript { get; set; }
        public int GroupId { get; set; }
        public decimal Price { get; set; }
        public OrderedDictionary Prop { get; set; }
        public ICollection<string> ImagePath { get; set; }
    }

    public class FilteredGoodsDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string ShortDescript { get; set; }
        public int GroupId { get; set; }
        public int PriceId { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
    }

}
