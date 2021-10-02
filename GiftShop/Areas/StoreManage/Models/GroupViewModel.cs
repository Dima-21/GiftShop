using BLL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Models
{
    public class GroupViewModel
    {
        public List<GroupDTO> Groups { get; set; }
    }

    public class CreateGroupViewModel
    {
        public GroupDTO Group { get; set; }
        public List<PropertyDTO> Properties { get; set; }

        public string ErrorMessage { get; set; }
        public IFormFile GroupImage { get; set; }

        public IFormFile GroupIcon { get; set; }

    }
}
