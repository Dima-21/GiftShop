using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class GoodsImageRepository : IRepository<GoodsImage>
    {
        GiftShopContext context = new GiftShopContext();

        ~GoodsImageRepository()
        {
            context.Dispose();
        }

        public void Create(GoodsImage item)
        {
            context.GoodsImage.Add(item);
        }

        public void Delete(int id)
        {
            context.GoodsImage.Remove(Get(id));
        }

        public GoodsImage Get(int id)
        {
            return context.GoodsImage.Find(id);
        }

        public IEnumerable<GoodsImage> GetAll()
        {
            return context.GoodsImage;
        }

        public IEnumerable<GoodsImage> Find(Func<GoodsImage, bool> predicate)
        {
            return context.GoodsImage.Where(predicate);
        }
        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(GoodsImage item)
        {
            context.GoodsImage.Update(item);
        }
    }
}
