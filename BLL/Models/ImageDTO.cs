using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class ImageDTO
    {
        public int Id { get; set; }

        [Display(Name = "Название картинки")]
        public string Name { get; set; }
    }
}
