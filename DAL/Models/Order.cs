using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderGoods = new HashSet<OrderGoods>();
        }

        public int Id { get; set; }
        //public int OrderId { get; set; }
        public string UserId { get; set; }
        public int OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrdCloseDate { get; set; }
        public int Sum { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RecipientName { get; set; }
        public string City { get; set; }
        public string BranchNumber { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<OrderGoods> OrderGoods { get; set; }
    }
}
