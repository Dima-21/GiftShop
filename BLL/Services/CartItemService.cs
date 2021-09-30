using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class CartItemService : IService<CartGoodsDTO>
    {

        private readonly IMapper _mapper;
        private readonly DataManager dataManager;
        public CartItemService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }
        public CartGoodsDTO Add(CartGoodsDTO item)
        {
            CartItem cartItem = _mapper.Map<CartItem>(item);
            cartItem.Goods = null;
            dataManager.RepoCartItem.Create(cartItem);
            dataManager.RepoCartItem.Save();

            return _mapper.Map<CartGoodsDTO>(cartItem);
        }

        public void Delete(int id)
        {
            dataManager.RepoCartItem.Delete(id);
            dataManager.RepoCartItem.Save();
        }

        public void Delete(CartGoodsDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(CartGoodsDTO item)
        {
            CartItem cartItem = _mapper.Map<CartItem>(item);

            dataManager.RepoCartItem.Update(cartItem);
            dataManager.RepoCartItem.Save();
        }

        //public IEnumerable<CartItemDTO> Find(Func<CartItemDTO, bool> predicate)
        //{
        //    IEnumerable<CartItem> cartItem = dataManager.RepoCartItem.Find(predicate.);
        //    List<CartItemDTO> result = _mapper.Map<List<CartItemDTO>>(cartItem);
        //    return result;
        //}

        public IEnumerable<CartGoodsDTO> GetAll()
        {
            IEnumerable<CartItem> cartItem  = dataManager.RepoCartItem.GetAll();
            List<CartGoodsDTO> result = _mapper.Map<List<CartGoodsDTO>>(cartItem);
            return result;
        }

        public CartGoodsDTO GetById(int id)
        {
            CartGoodsDTO goods = _mapper.Map<CartGoodsDTO>(dataManager.RepoGoods.Get(id));
            return goods;
        }

             
    }
}
