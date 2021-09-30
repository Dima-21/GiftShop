using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class OrderStatusRepository : IRepository<OrderStatus>
    {
        GiftShopContext context = new GiftShopContext();

        ~OrderStatusRepository()
        {
            context.Dispose();
        }
        public void Create(OrderStatus item)
        {
            context.OrderStatus.Add(item);
        }

        public void Delete(int id)
        {
            context.OrderStatus.Remove(Get(id));
        }

        public OrderStatus Get(int id)
        {
            return context.OrderStatus.Include(x => x.Orders)
                .ThenInclude(x => x.OrderGoods).ThenInclude(x => x.Goods)
                .ThenInclude(x=>x.GoodsImage).ThenInclude(x=>x.Image).FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<OrderStatus> GetAll()
        {
            return context.OrderStatus.Include(x => x.Orders);
        }

        public IEnumerable<OrderStatus> Find(Func<OrderStatus, bool> predicate)
        {
            return context.OrderStatus.Where(predicate);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(OrderStatus item)
        {
            context.OrderStatus.Update(item);
        }

        public void Delete(OrderStatus id)
        {
            throw new NotImplementedException();
        }
    }
}
