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
        }

        public void Delete(int id)
        {
            context.Goods.Remove(Get(id));
        }

        public Goods Get(int id)
        {
            return context.Goods.Find(id);
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
