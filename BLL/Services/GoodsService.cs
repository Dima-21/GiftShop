using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public GoodsService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public void Add(GoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            dataManager.RepoGoods.Delete(id);
            dataManager.RepoGoods.Save();
        }

        public void Edit(GoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GoodsDTO> GetAll()
        {
            List<GoodsDTO> result = new List<GoodsDTO>();

            foreach (var goods in dataManager.RepoGoods.GetAll())
            {
                GoodsDTO tmpGoods = new GoodsDTO();

                tmpGoods.Amount = goods.Amount;

                tmpGoods.Id = goods.Id;
                tmpGoods.Code = goods.Code;
                tmpGoods.Descript = goods.Descript;
                tmpGoods.IsHidden = goods.IsHidden;
                tmpGoods.Name = goods.Name;
                tmpGoods.Price = goods.Price;
                tmpGoods.ShortDescript = goods.ShortDescript;

                tmpGoods.Group = _mapper.Map<GroupDTO>(dataManager.RepoGroup.GetAll().FirstOrDefault(x => x.Id == goods.GroupId));
                List<GoodsImage> tmpGoodsImage = dataManager.RepoGoodsImage.GetAll().Where(x => x.GoodsId == goods.Id).ToList();
                tmpGoods.GoodsImage = new List<ImageDTO>();
                tmpGoodsImage.ForEach(x =>
                {
                    tmpGoods.GoodsImage.Add(_mapper.Map<ImageDTO>(dataManager.RepoImage.GetAll().FirstOrDefault(i => i.Id == x.ImageId)));
                });
                if (tmpGoods.GoodsImage.Count == 0)
                {
                    tmpGoods.GoodsImage.Add(new ImageDTO() { Name = "without-photo.png" });
                }

                tmpGoods.PropCharact = new List<PropertyValueDTO>();
                List<Charact> tmpProp = dataManager.RepoCharact.GetAll().Where(x => x.GoodsId == goods.Id).ToList();
                tmpProp.ForEach(x =>
                {
                    PropertyValueDTO prop = _mapper.Map<PropertyValueDTO>(dataManager.RepoProperty.GetAll().FirstOrDefault(p => p.Id == x.PropId));
                    prop.Value = x.Value;
                    tmpGoods.PropCharact.Add(prop);
                });

                result.Add(tmpGoods);
            }

            return result;
        }
    }
}
