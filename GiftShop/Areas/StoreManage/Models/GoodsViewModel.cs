﻿using BLL.Models;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Models
{
    public class GoodsListViewModel
    {
        public List<GoodsViewModel> Goods { get; set; }
        public List<GroupDTO> Groups { get; set; }
        public int SelectedGroupId { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
    public class GoodsViewModel
    {
        private string shortDescript;
        private string descript;

        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Descript
        {
            get
            {
                if (string.IsNullOrEmpty(descript) || descript.Length > 30)
                    return $"{descript?.Substring(0, 30)}...";
                return descript;
            }
            set => descript = value;
        }

        [Display(Name = "Краткое описание")]
        public string ShortDescript
        {
            get
            {
                if (string.IsNullOrEmpty(shortDescript) || shortDescript.Length > 30)
                    return $"{shortDescript?.Substring(0, 30)}...";
                return shortDescript;
            }
            set => shortDescript = value;
        }

        [Display(Name = "Категория")]
        public string Group { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Скрыть товар")]
        public bool IsHidden { get; set; }

        [Display(Name = "Кол-во")]
        public short Amount { get; set; }

        [Display(Name = "Фото")]
        public string Image { get; set; }
    }

    public class CreateGoodsViewModel
    {
        public GoodsDTO Goods { get; set; }
        public List<GroupDTO> Groups { get; set; }
        public IEnumerable<IFormFile> Images { get; set; }
        public List<PropertyValueDTO> Properties { get; set; }

        //public PropertiesListViewModel Properties { get; set; }
        //public List<PropertyDTO> Characts { get; set; }




        //public int Id { get; set; }

        //[Display(Name = "Код")]
        //public int Code { get; set; }

        //[Display(Name = "Наименование")]
        //public string Name { get; set; }

        //[Display(Name = "Описание")]
        //public string Descript { get; set; }

        //[Display(Name = "Краткое описание")]
        //public string ShortDescript { get; set; }

        //[Display(Name = "Категория")]
        //public string Group { get; set; }

        //[Display(Name = "Цена")]
        //public decimal Price { get; set; }

        //[Display(Name = "Показать на сайте")]
        //public bool IsHidden { get; set; }

        //[Display(Name = "Кол-во")]
        //public short Amount { get; set; }

        //[Display(Name = "Фото")]
        //public List<ImageDTO> Images { get; set; }

        //public List<PropertyDTO> Properties { get; set; }
    }

    public class CharacteristicViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }


}
