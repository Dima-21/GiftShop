using AutoMapper;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Infrastructure
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<GoodsDTO, Areas.StoreManage.Models.GoodsViewModel>();
        }
    }
}
