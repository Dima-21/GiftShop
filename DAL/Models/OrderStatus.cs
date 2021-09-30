using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class OrderStatus
    {
        public short Id { get; set; }
        public string StatusName { get; set; }
        public short StatusCode { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
