using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : IRepository<AspNetUsers>
    {
        GiftShopContext context = new GiftShopContext();

        ~UserRepository()
        {
            context.Dispose();
        }

        public void Create(AspNetUsers item)
        {
            throw new NotImplementedException();
            //context.Entry<Goods>(item).State = EntityState.Detached;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(AspNetUsers id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AspNetUsers> Find(Func<AspNetUsers, bool> predicate)
        {
            return context.AspNetUsers
                .Include(x => x.Order).ThenInclude(x=>x.OrderGoods).ThenInclude(x=>x.Goods).ThenInclude(x=>x.GoodsImage).ThenInclude(x=>x.Image)
                .Include(x => x.Order).ThenInclude(x=>x.OrderStatus)
                .Where(predicate);
        }

        public AspNetUsers Get(int id)
        {
            throw new NotImplementedException();

            //return context.AspNetUsers.Include(x=>x.Order).FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<AspNetUsers> GetAll()
        {
            return context.AspNetUsers;
            //return context.Goods;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(AspNetUsers item)
        {
            throw new NotImplementedException();
        }
    }
}
