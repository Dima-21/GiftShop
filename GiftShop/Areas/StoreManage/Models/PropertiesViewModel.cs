using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Models
{
    public class PropertiesViewModel
    {
        public PropertyDTO Property { get; set; }
        public List<CharactDTO> Characts { get; set; }
    }

    //public class PropertiesListViewModel
    //{
    //    public List<PropertyValueDTO> Properties { get; set; }
    //    public List<PropertyDTO> Characts { get; set; }
    //}
}
