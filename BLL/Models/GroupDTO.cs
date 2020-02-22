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
    }
}
