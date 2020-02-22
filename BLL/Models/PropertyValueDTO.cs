using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class PropertyValueDTO
    {
        public int Id { get; set; }

        [Display(Name = "Название свойства")]
        public string Name { get; set; }

        [Display(Name = "Значение")]
        public string Value { get; set; }

        [Display(Name = "Участие в фильтрации")]
        public bool IsFilter { get; set; }
    }
}

