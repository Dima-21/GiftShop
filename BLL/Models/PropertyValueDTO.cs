using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class PropertyValueDTO
    {
        public int PropId { get; set; }

        [Display(Name = "Название свойства")]
        public string Name { get; set; }

        [Display(Name = "Характеристика")]
        public string Value { get; set; }

    }
}

