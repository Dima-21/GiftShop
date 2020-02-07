using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class PriceRepository : IRepository<Price>
    {
        GiftShopContext context = new GiftShopContext();

        public void Create(Price item)
        {
            context.Price.Add(item);
        }

        public void Delete(int id)
        {
            context.Price.Remove(Get(id));
        }

        public Price Get(int id)
        {
            return context.Price.Find(id);
        }

        public IEnumerable<Price> GetAll()
        {
            return context.Price;
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Price item)
        {
            context.Price.Update(item);
        }
    }
}
