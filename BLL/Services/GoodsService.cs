using BLL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class GoodsService : IService<GoodsDTO>
    {
        IRepository<Goods> repo;

        public GoodsService(IRepository<Goods> repo)
        {
            this.repo = repo;
        }

        public void Add(GoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(GoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDTO> GetAll()
        {
            List<GoodsDTO> result = new List<GoodsDTO>();

            List<string> pict = new List<string>();
            pict.Add("without-photo.png");

            result = repo.GetAll().Select(x => new GoodsDTO
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                ShortDescript = x.ShortDescript,
                //GroupId = x.GroupId,
                ImagePath = pict,
                Price = x.Price?.OrigPrice ?? 0,
                PriceId = x.PriceId
            }).ToList();

            //context.Goods.Join(context.Price, // второй набор
            //    p => p.PriceId, // свойство-селектор объекта из первого набора
            //    c => c.Id, // свойство-селектор объекта из второго набора
            //    (p, c) => new Goods()// результат
            //    {
            //        Id = p.Id,
            //        GroupId = p.GroupId,
            //        Name = p.Name,
            //        Price = p.Price
            //    });

            return result;

        }

        //public IEnumerable<FilteredGoodsDTO> GetAllFiltered(int? groupId)
        //{
        //    List<FilteredGoodsDTO> result = new List<FilteredGoodsDTO>();
            
        //    if (groupId is null)
        //        result = repo.GetAll().Select(x => new FilteredGoodsDTO
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            Code = x.Code,
        //            ShortDescript = x.ShortDescript,
        //            GroupId = x.GroupId,
        //            ImagePath = x.GoodsImage.Count == 0 ? "without-photo.png" : $"{x.GoodsImage.First().Image.Name}",
        //            Price = x.Price?.OrigPrice ?? 0,
        //            PriceId = x.PriceId
        //        }).ToList();

        //    return result;
        //}
    }
}
