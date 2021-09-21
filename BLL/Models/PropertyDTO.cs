using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class PropertyDTO
    {
        public int PropId { get; set; }
        public int GroupId { get; set; }
        public int GoodsId { get; set; }

        [Display(Name = "Название свойства")]
        public string Name { get; set; }

        [Display(Name = "Значение")]
        public ICollection<CharactDTO> Charact { get; set; }

        [Display(Name = "Участие в фильтрации")]
        public bool IsFilter { get; set; }

        
    }
}

