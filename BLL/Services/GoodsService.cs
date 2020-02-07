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
            result = repo.GetAll().Select(x => new GoodsDTO
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                ShortDescript = x.ShortDescript,
                GroupId = x.GroupId,
                //ImagePath = $"{ x.GoodsImage.First().Image.Name} . {x.GoodsImage.First().Image.Fext}",
                Price = x.Price?.OrigPrice ?? 0,
                PriceId = x.PriceId
            }).ToList();

            return result;

        }

        public IEnumerable<FilteredGoodsDTO> GetAllFiltered(int? groupId)
        {
            List<FilteredGoodsDTO> result = new List<FilteredGoodsDTO>();
            
            if (groupId is null)
                result = repo.GetAll().Select(x => new FilteredGoodsDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code,
                    ShortDescript = x.ShortDescript,
                    GroupId = x.GroupId,
                    ImagePath = x.GoodsImage.Count == 0 ? "without-photo.png" : $"{ x.GoodsImage.First().Image.Name}.{x.GoodsImage.First().Image.Fext}",
                    Price = x.Price?.OrigPrice ?? 0,
                    PriceId = x.PriceId
                }).ToList();

            return result;
        }
    }
}
