using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class OrderGoodsRepository : IRepository<OrderGoods>
    {
        GiftShopContext context = new GiftShopContext();
        ~OrderGoodsRepository()
        {
            context.Dispose();
        }
        public void Create(OrderGoods item)
        {
            context.OrderGoods.Add(item);
        }

        public void Delete(int id)
        {
            context.OrderGoods.Remove(Get(id));
        }

        public OrderGoods Get(int id)
        {
            return context.OrderGoods.Find(id);
        }

        public IEnumerable<OrderGoods> GetAll()
        {
            return context.OrderGoods;
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(OrderGoods item)
        {
            context.OrderGoods.Update(item);
        }
    }
}
