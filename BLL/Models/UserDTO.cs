using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
