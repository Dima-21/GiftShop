using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class PropertyRepository : IRepository<Property>
    {
        GiftShopContext context = new GiftShopContext();

        public void Create(Property item)
        {
            context.Property.Add(item);
        }

        public void Delete(int id)
        {
            context.Property.Remove(Get(id));
        }

        public Property Get(int id)
        {
            return context.Property.AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Property> GetAll()
        {
            return context.Property.Include(x => x.Charact);
        }

        public IEnumerable<Property> Find(Func<Property, bool> predicate)
        {
            return context.Property.AsNoTracking().Where(predicate);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Property item)
        {
            context.Property.Update(item);
        }

        public void Delete(Property id)
        {
            throw new NotImplementedException();
        }
    }
}
