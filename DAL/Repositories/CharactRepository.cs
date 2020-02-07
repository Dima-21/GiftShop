using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    class CharactRepository : IRepository<Charact>
    {
        GiftShopContext context = new GiftShopContext();

        ~CharactRepository()
        {
            context.Dispose();
        }
        public void Create(Charact item)
        {
            context.Charact.Add(item);
        }

        public void Delete(int id)
        {
            context.Charact.Remove(Get(id));
        }

        public Charact Get(int id)
        {
            return context.Charact.Find(id);
        }

        public IEnumerable<Charact> GetAll()
        {
            return context.Charact;
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Charact item)
        {
            context.Charact.Update(item);
        }
    }
}
