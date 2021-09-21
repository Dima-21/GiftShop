using AutoMapper;
using BLL.Models;
using DAL.Models;
using GiftShop.Areas.ProductList.Models;
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
                .ForMember(vm => vm.Image, conf => conf.MapFrom(dto => dto.GoodsImage.FirstOrDefault() != null ? dto.GoodsImage.FirstOrDefault().Name : null));

            CreateMap<Goods, GoodsDTO>()
                .ForMember(dto => dto.GoodsImage, conf => conf.MapFrom(x => x.GoodsImage.Select(y => y.Image).ToList()))
                .ForMember(dto => dto.PropCharact, conf => conf.MapFrom(x => x.Charact));

            //CreateMap<Goods, GoodsDTO>()
            //    .ForMember(dto => dto.GoodsImage, conf => conf.MapFrom(x => x.GoodsImage.Select(y => y.Image).ToList()))
            //    .ForMember(dto => dto.PropCharact, conf => conf.MapFrom(x => x.Charact.Select(y => y.Prop).ToList()));

            CreateMap<GoodsDTO, Goods>()
             .ForMember(dest => dest.GoodsImage, conf => conf.MapFrom(x => x.GoodsImage))
             .ForMember(dest => dest.Charact, conf => conf.MapFrom(x => x.PropCharact))
             .ForMember(dest => dest.Group, conf => conf.Ignore());
            // test
            //.ForMember(dest => dest.Id, conf => conf.Ignore());
            CreateMap<Image, GoodsImage>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src));

            //CreateMap<Property, Charact>()
            //    .ForMember(dest => dest.Prop, opt => opt.MapFrom(src => src));
            CreateMap<Charact, PropertyDTO>().ReverseMap();
            CreateMap<Charact, PropertyValueDTO>().ReverseMap();

            CreateMap<ImageDTO, GoodsImage>()
                  .ForMember(d => d.ImageId, opt => opt.MapFrom(s => s.Id))
                  .ForMember(d => d.Image, opt => opt.MapFrom(s => s));

            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();


            CreateMap<CartGoodsDTO, OrderGoods>()
                 .ForMember(dest => dest.GoodsId, opt => opt.MapFrom(x => x.Goods.Id))
                 .ForMember(dest => dest.Goods, opt => opt.Ignore())
                 .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Amount))
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Sum));

            CreateMap<OrderDTO, OrderGoods>()
                 .ForMember(dest => dest.Price, opt => opt.MapFrom(x => x.Sum))
                 .ForMember(dest => dest.Amount, opt => opt.MapFrom(x => x.Amount));

            //CreateMap<OrderDTO, Order>()
            //     .ForMember(dest => dest.OrderGoods, opt => opt.MapFrom(x => x.Goods));

            CreateMap<OrderDTO, Order>()
             .ForMember(dest => dest.OrderGoods, opt => opt.MapFrom(x => x.Goods.Select(y => y)));


            CreateMap<Order, OrderDTO>()
                 .ForMember(dto => dto.Goods, opt => opt.MapFrom(x => x.OrderGoods.Select(y => y.Goods).ToList()));


            //.ForMember(dest => dest.Goods, conf => conf.MapFrom(x => x.OrderGoods)).ReverseMap();
            //CreateMap<OrderGoods, OrderDTO>()
            //    .ForMember(dest => dest.Goods, conf => conf.MapFrom(x => x.Goods))
            //    .ReverseMap();
            //CreateMap<PropertyDTO, Charact>().ReverseMap();
            CreateMap<Property, PropertyDTO>()
                .ForMember(dest => dest.PropId, conf => conf.MapFrom(x => x.Id))
                .ForMember(dest => dest.Charact, conf => conf.MapFrom(x => x.Charact));

            CreateMap<Charact, CharactDTO>();

            //CreateMap<Charact, PropertyDTO>()
            //    .ForMember(dest => dest.Name, conf => conf.MapFrom(x => x.Prop.Name))
            //    .ReverseMap();

            CreateMap<CartItem, CartGoodsDTO>()
                .ForMember(dest => dest.ShopCardId, conf => conf.MapFrom(x => x.ShopCartId))
                .ReverseMap();

            CreateMap<IEnumerable<PropertyDTO>, FilterViewModel>()
                .ForMember(dest => dest.GroupedProperties, conf => conf.MapFrom(x => x.Select(y=>y)));


            CreateMap<PropertyDTO, GroupedProperties>().ReverseMap();

            CreateMap<CharactItem, CharactDTO>();
            CreateMap<CharactDTO, CharactItem>();
        }
    }
}
