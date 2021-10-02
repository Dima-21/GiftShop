using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class GroupDTO
    {
        public int Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Иконка категории")]
        public string Icon { get; set; }

        [Display(Name = "Картинка категории")]
        public string Image { get; set; }

        [Display(Name = "Количество товаров")]
        public int NumberGoods { get; set; }

        [Display(Name = "Количество доступных товаров")]
        public int NumberAvailableGoods { get; set; }

        [Display(Name = "Описание")]
        public string ShortDescript { get; set; }

        [Display(Name = "Скрыть группу")]
        public bool IsHidden { get; set; }

        public List<PropertyDTO> Properties { get; set; }
    }
}
