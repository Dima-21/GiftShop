using AutoMapper;
using BLL.Models;
using DAL.Models;
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
            CreateMap<GoodsDTO, Areas.StoreManage.Models.GoodsViewModel>()
                .ForMember(vm => vm.Group, conf => conf.MapFrom(dto => dto.Group.Name))
                .ForMember(vm => vm.Image, conf => conf.MapFrom(dto => dto.GoodsImage[0].Name));
            CreateMap<Group, GroupDTO>();
            CreateMap<Image, ImageDTO>();
            CreateMap<Property, PropertyValueDTO>();
        }
    }
}
