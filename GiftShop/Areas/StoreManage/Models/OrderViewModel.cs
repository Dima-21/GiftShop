using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Models
{
    public class OrderDetailsViewModel
    {
        public OrderDTO Order { get; set; }
    }
    public class OrderListViewModel
    {
        public List<ListWithSelectOrderViewModel> Orders{ get; set; }
        public List<OrderStatusDTO> OrderStatusList{ get; set; }
        public OrderStatusDTO SelectedStatus{ get; set; }
    }

    public class ListWithSelectOrderViewModel
    {
        public OrderDTO Order { get; set; }
        public bool AreChecked { get; set; }
    }
}
