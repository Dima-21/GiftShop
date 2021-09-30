using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class OrderStatusDTO
    {
        public short Id { get; set; }
        public string StatusName { get; set; }
        public short StatusCode { get; set; }
        public short NumberOrders { get; set; }
        public List<OrderDTO> Orders{ get; set; }
    }
}
