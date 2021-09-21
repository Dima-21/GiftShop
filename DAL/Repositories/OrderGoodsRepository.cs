using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class OrderGoodsRepository : IRepository<OrderGoods>
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

        public IEnumerable<OrderGoods> Find(Func<OrderGoods, bool> predicate)
        {
            return context.OrderGoods.Include(x => x.Goods).Where(predicate);
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
