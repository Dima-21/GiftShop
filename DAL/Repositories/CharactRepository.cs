using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CharactRepository : IRepository<Charact>
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
        public IEnumerable<Charact> Find(Func<Charact, bool> predicate)
        {
            return context.Charact.Where(predicate);
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
