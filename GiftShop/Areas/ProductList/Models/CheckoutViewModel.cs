using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.ProductList.Models
{
    public class CheckoutViewModel
    {
    }

    public class ShippingDetails
    {
        [Required(ErrorMessage = "Укажите Ваше ФИО")]
        [Display(Name = "ФИО")]
        public string RecipientName { get; set; }

        [Required(ErrorMessage = "Укажите Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите Ваш номер телефона")]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Укажите номер отделения Новой Почты")]
        [Display(Name = "№ отделения")]
        public string BranchNumber { get; set; }


        [Required(ErrorMessage = "Укажите город доставки")]
        [Display(Name = "Область, город")]
        public string City { get; set; }

    }
}
