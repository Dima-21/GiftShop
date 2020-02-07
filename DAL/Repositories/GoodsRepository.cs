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

            IQueryable<Goods> goods = context.Goods.Join(context.Price, // второй набор
                p => p.PriceId, // свойство-селектор объекта из первого набора
                c => c.Id, // свойство-селектор объекта из второго набора
                (p, c) => new Goods()// результат
                {
                    Name = p.Name,
                    Price = p.Price
                });

            return goods;
            //return context.Goods;
        }

        public void Save()
        {
            context.SaveChangesAsync();
        }

        public void Update(Goods item)
        {
            context.Goods.Update(item);
        }
    }
}
