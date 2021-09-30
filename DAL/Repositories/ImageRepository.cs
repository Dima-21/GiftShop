using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        GiftShopContext context = new GiftShopContext();
        public void Create(Image item)
        {
          context.Image.Add(item);
        }

        public void Delete(int id)
        {
            context.Image.Remove(Get(id));
        }

        public Image Get(int id)
        {
            return context.Image.Find(id);
        }

        public IEnumerable<Image> GetAll()
        {
            return context.Image;
        }

        public IEnumerable<Image> Find(Func<Image, bool> predicate)
        {
            return context.Image.Where(predicate);
        }
        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Image item)
        {
            context.Image.Update(item);
        }

        public void Delete(Image id)
        {
            throw new NotImplementedException();
        }
    }
}
