using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class GoodsRepository : IRepository<Goods>
    {
        GiftShopContext context = new GiftShopContext();

        ~GoodsRepository()
        {
            context.Dispose();
        }

        public void Create(Goods item)
        {
            context.Goods.Add(item);
            //context.Entry<Goods>(item).State = EntityState.Detached;
        }

        public void Delete(int id)
        {
            context.Goods.Remove(Get(id));
        }

        public void Delete(Goods id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Goods> Find(Func<Goods, bool> predicate)
        {
            return context.Goods.Where(predicate);
        }

        public Goods Get(int id)
        {
            return context.Goods.AsNoTracking().Include(x => x.Group)
                                .Include(x => x.GoodsImage).ThenInclude(x => x.Image)
                                .Include(x => x.Charact).ThenInclude(x => x.Prop).FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<Goods> GetAll()
        {
            return context.Goods.Include(x => x.Group)
                                .Include(x => x.GoodsImage).ThenInclude(x => x.Image)
                                .Include(x => x.Charact).ThenInclude(x => x.Prop);
            //return context.Goods;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Goods item)
        {
            context.Goods.Update(item);
        }
    }
}
