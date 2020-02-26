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

            CreateMap<Goods, GoodsDTO>()
                .ForMember(dto => dto.GoodsImage, conf => conf.MapFrom(x => x.GoodsImage.Select(y => y.Image).ToList()))
                .ForMember(dto => dto.PropCharact, conf => conf.MapFrom(x => x.Charact.Select(y => y.Prop).ToList()))
                .ForMember(dto => dto.PropCharact., conf => conf.MapFrom(x => x.Charact.Select(y => y.Prop).ToList()))
                .ReverseMap();

            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>();
            CreateMap<Property, PropertyValueDTO>();
        }
    }
}
