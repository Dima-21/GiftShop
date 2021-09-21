using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class CartGoodsDTO
    {
        public long? Id { get; set; }
        public string ShopCardId { get; set; }
        [Display(Name = "Количество")]
        public int Amount { get; set; }
        [Display(Name = "Сумма")]
        public decimal Sum { get { return Amount * Goods.Price; } }
        public GoodsDTO Goods { get; set; }
    }
}
