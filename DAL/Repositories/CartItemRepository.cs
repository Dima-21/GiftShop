using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class CartItemRepository : IRepository<CartItem>
    {
        GiftShopContext context = new GiftShopContext();

        ~CartItemRepository()
        {
            context.Dispose();
        }

        public void Create(CartItem item)
        {
            context.CartItem.Add(item);
        }

        public void Delete(int id)
        {
            context.CartItem.Remove(Get(id));
        }

        public void Delete(CartItem id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> Find(Func<CartItem, bool> predicate)
        {
            return context.CartItem.Where(predicate);
        }

        public CartItem Get(int id)
        {
            return context.CartItem.Include(x => x.Goods).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CartItem> GetAll()
        {
            return context.CartItem.Include(x => x.Goods);
            //return context.CartItem;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(CartItem item)
        {
            context.CartItem.Update(item);
        }

    }
}
