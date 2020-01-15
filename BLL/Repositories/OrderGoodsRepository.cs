using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
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
            throw new NotImplementedException();
        }

        public OrderGoods Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderGoods> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderGoods item)
        {
            throw new NotImplementedException();
        }
    }
}
