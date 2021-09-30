using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Номер заказа")]
        public int OrderNum { get; set; }
        [Display(Name = "Дата заказа")]
        public DateTime OrderDate { get; set; }
        public DateTime? OrdCloseDate { get; set; }
        [Display(Name = "К-во")]
        public short Amount { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Эл.почта")]
        public string Email { get; set; }
        [Display(Name = "ФИО")]
        public string RecipientName { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Номер отделения")]
        public string BranchNumber { get; set; }
        public short OrderStatusId { get; set; }
        [Display(Name = "Статус заказа")]
        public string OrderStatus { get; set; }
        [Display(Name = "Сумма заказа")]
        public decimal Sum
        {
            get
            {
                return Goods?.Sum(x => x.Sum)??0;
            }
        }

        public List<CartGoodsDTO> Goods { get; set; }
    }



}
