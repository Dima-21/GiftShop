using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.Models
{
    public class GoodsDTO
    {
        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        public int PriceId { get; set; }

        [Display(Name = "Описание")]
        public string Descript { get; set; }

        [Display(Name = "Краткое описание")]
        public string ShortDescript { get; set; }
        public GroupDTO Group { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Показать на сайте")]
        public bool IsHidden { get; set; }

        [Display(Name = "Кол-во")]
        public short Amount { get; set; }

        public OrderedDictionary PropCharact { get; set; } // Характеристика товара

        public OrderedDictionary GoodsImage { get; set; } // Фото товара

        [Display(Name = "Фото")]
        public ICollection<string> ImagePath { get; set; }

    }

    //public class FilteredGoodsDTO
    //{
    //    public int Id { get; set; }
    //    public int Code { get; set; }
    //    public string Name { get; set; }
    //    public string ShortDescript { get; set; }
    //    public int GroupId { get; set; }
    //    public int PriceId { get; set; }
    //    public decimal Price { get; set; }
    //    public string ImagePath { get; set; }
    //}

}
