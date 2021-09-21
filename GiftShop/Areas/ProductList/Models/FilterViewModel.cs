using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.ProductList.Models
{
    public class FilterViewModel
    {
        //public int? GroupId { get; set; }
        public GroupDTO CurrCategory { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        public List<GroupedProperties> GroupedProperties { get; set; }
    }

    public class GroupedProperties
    {
        public int PropId{ get; set; }
        public string Name{ get; set; }
        public List<CharactItem> Charact{ get; set; }
    }

    public class CharactItem
    {
        public string Value { get; set; }
        public bool AreChecked { get; set; }
    }
}
