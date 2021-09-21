using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        GiftShopContext context = new GiftShopContext();

        ~OrderRepository()
        {
            context.Dispose();
        }
        public void Create(Order item)
        {
            context.Order.Add(item);
        }

        public void Delete(int id)
        {
            context.Order.Remove(Get(id));
        }

        public Order Get(int id)
        {
            return context.Order.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Order;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return context.Order.Where(predicate);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Order item)
        {
            context.Order.Update(item);
        }
    }
}
