using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderGoodsService : IService<OrderGoodsDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public OrderGoodsService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public OrderGoodsDTO Add(OrderGoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderGoodsDTO item)
        {
            OrderGoods order = _mapper.Map<OrderGoods>(item);
            dataManager.RepoOrderGoods.Delete(order);
            dataManager.RepoOrderGoods.Save();
        }

        public void Edit(OrderGoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderGoodsDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderGoodsDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
