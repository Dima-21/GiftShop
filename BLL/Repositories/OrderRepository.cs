using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    class OrderRepository : IRepository<Order>
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
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
