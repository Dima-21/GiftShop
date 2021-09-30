using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        GiftShopContext context = new GiftShopContext();
        ~GroupRepository()
        {
            context.Dispose();
        }
        public void Create(Group item)
        {
            context.Group.Add(item);
        }

        public void Delete(int id)
        {
            context.Group.Remove(Get(id));
        }

        public Group Get(int id)
        {
            return context.Group.Include(x=>x.Properties).FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Group> GetAll()
        {
            return context.Group.Include(x=>x.Goods);
        }
        public IEnumerable<Group> Find(Func<Group, bool> predicate)
        {
            return context.Group.Where(predicate);
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Group item)
        {
            context.Group.Update(item);
        }

        public void Delete(Group id)
        {
            throw new NotImplementedException();
        }
    }
}
