using DAL.Models;
using System;
using System.Collections.Generic;
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
            return context.Property.Find(id);
        }

        public IEnumerable<Property> GetAll()
        {
            return context.Property;
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Property item)
        {
            context.Property.Update(item);
        }
    }
}
