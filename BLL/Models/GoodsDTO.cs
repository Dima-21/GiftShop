using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class GoodsDTO
    {
        public int? Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Descript { get; set; }

        [Display(Name = "Краткое описание")]
        public string ShortDescript { get; set; }

        [Display(Name = "Категория")]
        public GroupDTO Group { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Скрыть товар")]
        public bool IsHidden { get; set; }

        [Display(Name = "Кол-во")]
        public short Amount { get; set; }

        public List<PropertyValueDTO> PropCharact { get; set; } // Характеристика товара

        [Display(Name = "Фото")]
        public List<ImageDTO> GoodsImage { get; set; } // Фото товара

        public DateTime PublishData { get; set; }

        //[Display(Name = "Фото")]
        //public ICollection<string> ImagePath { get; set; }

    }




    //public class GoodsForTableDTO
    //{
    //    private string shortDescript;
    //    private string descript;

    //    public int Id { get; set; }

    //    [Display(Name = "Код")]
    //    public int Code { get; set; }

    //    [Display(Name = "Наименование")]
    //    public string Name { get; set; }

    //    [Display(Name = "Описание")]
    //    public string Descript { get => $"{descript.Take(30).ToString()}..."; set => descript = value; }

    //    [Display(Name = "Краткое описание")]
    //    public string ShortDescript { get => $"{shortDescript.Take(30).ToString()}..."; set => shortDescript = value; }

    //    [Display(Name = "Категория")]
    //    public string Group { get; set; }

    //    [Display(Name = "Цена")]
    //    public decimal Price { get; set; }

    //    [Display(Name = "Показать на сайте")]
    //    public bool IsHidden { get; set; }

    //    [Display(Name = "Кол-во")]
    //    public short Amount { get; set; }

    //    [Display(Name = "Фото")]
    //    public string Image { get; set; }
    //}

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
