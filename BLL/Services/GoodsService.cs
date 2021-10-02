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

        public GoodsDTO Add(GoodsDTO item)
        {
            //Image img = _mapper.Map<Image>(item.GoodsImage.First());
            //dataManager.RepoImage.Create(img);
            //dataManager.RepoImage.Save();
            item.PropCharact = item?.PropCharact?.Where(x => !string.IsNullOrEmpty(x.Value)).ToList();
            Goods goods = _mapper.Map<Goods>(item);
            //goods.Id = int.MinValue;
            dataManager.RepoGoods.Create(goods);
            dataManager.RepoGoods.Save();

            return _mapper.Map<GoodsDTO>(goods);
        }

        public void Delete(int id)
        {
            dataManager.RepoGoods.Delete(id);
            dataManager.RepoGoods.Save();
        }

        public void Delete(GoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(GoodsDTO item)
        {
            item.PropCharact?.RemoveAll(x => string.IsNullOrEmpty(x.Value));
            item.GoodsImage?.RemoveAll(x => x.Id != 0);

            Goods goods = _mapper.Map<Goods>(item);

            foreach (var goodsImage in goods.GoodsImage)
            {
                goodsImage.GoodsId = goods.Id;
            }

            foreach (var charact in goods.Charact)
            {
                var charactEntity = dataManager.RepoCharact.Find(x => x.PropId == charact.PropId && x.GoodsId == goods.Id);

                charact.GoodsId = goods.Id;
                if (charactEntity == null || charactEntity.Count()==0)
                {
                    dataManager.RepoCharact.Create(charact);
                    dataManager.RepoCharact.Save();
                }
            }

            //goods.PublishData = DateTime.Now;
            dataManager.RepoGoods.Update(goods);
            dataManager.RepoGoods.Save();
        }

        public IEnumerable<GoodsDTO> GetAll()
        {
            List<Goods> goods = dataManager.RepoGoods.GetAll().ToList();
            List<GoodsDTO> result = _mapper.Map<List<GoodsDTO>>(goods);


            //List <GoodsDTO> result = new List<GoodsDTO>();

            //foreach (var goods in dataManager.RepoGoods.GetAll())
            //{
            //    GoodsDTO tmpGoods = new GoodsDTO();

            //    tmpGoods.Amount = goods.Amount;

            //    tmpGoods.Id = goods.Id;
            //    tmpGoods.Code = goods.Code;
            //    tmpGoods.Descript = goods.Descript;
            //    tmpGoods.IsHidden = goods.IsHidden;
            //    tmpGoods.Name = goods.Name;
            //    tmpGoods.Price = goods.Price;
            //    tmpGoods.ShortDescript = goods.ShortDescript;

            //    tmpGoods.Group = _mapper.Map<GroupDTO>(dataManager.RepoGroup.GetAll().FirstOrDefault(x => x.Id == goods.GroupId));
            //    List<GoodsImage> tmpGoodsImage = dataManager.RepoGoodsImage.GetAll().Where(x => x.GoodsId == goods.Id).ToList();
            //    tmpGoods.GoodsImage = new List<ImageDTO>();
            //    tmpGoodsImage.ForEach(x =>
            //    {
            //        tmpGoods.GoodsImage.Add(_mapper.Map<ImageDTO>(dataManager.RepoImage.GetAll().FirstOrDefault(i => i.Id == x.ImageId)));
            //    });
            //    if (tmpGoods.GoodsImage.Count == 0)
            //    {
            //        tmpGoods.GoodsImage.Add(new ImageDTO() { Name = "without-photo.png" });
            //    }

            //    tmpGoods.PropCharact = new List<PropertyDTO>();
            //    List<Charact> tmpProp = dataManager.RepoCharact.GetAll().Where(x => x.GoodsId == goods.Id).ToList();
            //    tmpProp.ForEach(x =>
            //    {
            //        PropertyDTO prop = _mapper.Map<PropertyDTO>(dataManager.RepoProperty.GetAll().FirstOrDefault(p => p.Id == x.PropId));
            //        prop.Value = x.Value;
            //        tmpGoods.PropCharact.Add(prop);
            //    });

            //    result.Add(tmpGoods);
            //}

            return result;
        }

        public GoodsDTO GetById(int id)
        {
            Goods goods = dataManager.RepoGoods.Get(id);
            GoodsDTO goodsDTO = _mapper.Map<GoodsDTO>(goods);
            return goodsDTO;
        }
    }
}
