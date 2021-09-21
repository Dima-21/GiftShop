using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int OrderNum { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrdCloseDate { get; set; }
        public decimal Sum
        {
            get
            {
                return Goods.Sum(x => x.Sum);
            }
        }
        public short Amount { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string RecipientName { get; set; }
        public string City { get; set; }
        public string BranchNumber { get; set; }
        public ICollection<CartGoodsDTO> Goods { get; set; }

    }
}
