using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.ProductList.Models
{
    public class ShopCart
    {
       
        //private List<CartLine> cartLine = new List<CartLine>();

        //public void AddItem(GoodsDTO goods, int quantity)
        //{
        //    Cart line = cartLine.
        //        .Where(g => g. == goods.Id)
        //        .FirstOrDefault();

        //    if (line == null)
        //    {
        //        cartLine.Add(new CartLine
        //        {
        //            Goods = goods,
        //            Quantity = quantity
        //        });
        //    }
        //    else
        //    {
        //        line.Quantity += quantity;
        //    }
        //}

        //public void RemoveLine(GoodsDTO goods)
        //{
        //    cartLine.RemoveAll(l => l.Goods.Id == goods.Id);
        //}

        //public decimal ComputeTotalValue()
        //{
        //    return cartLine.Sum(e => e.Goods.Price * e.Quantity);

        //}
        //public void Clear()
        //{
        //    cartLine.Clear();
        //}

        //public IEnumerable<CartLine> Lines
        //{
        //    get { return cartLine; }
        //}



        //    private List<CartLine> cartLine = new List<CartLine>();

        //    public void AddItem(GoodsDTO goods, int quantity)
        //    {
        //        CartLine line = cartLine
        //            .Where(g => g.Goods.Id == goods.Id)
        //            .FirstOrDefault();

        //        if (line == null)
        //        {
        //            cartLine.Add(new CartLine
        //            {
        //                Goods = goods,
        //                Quantity = quantity
        //            });
        //        }
        //        else
        //        {
        //            line.Quantity += quantity;
        //        }
        //    }

        //    public void RemoveLine(GoodsDTO goods)
        //    {
        //        cartLine.RemoveAll(l => l.Goods.Id == goods.Id);
        //    }

        //    public decimal ComputeTotalValue()
        //    {
        //        return cartLine.Sum(e => e.Goods.Price * e.Quantity);

        //    }
        //    public void Clear()
        //    {
        //        cartLine.Clear();
        //    }

        //    public IEnumerable<CartLine> Lines
        //    {
        //        get { return cartLine; }
        //    }
        //}

        public class CartLine
        {
            public GoodsDTO Goods { get; set; }
            public int Quantity { get; set; }
        }
    }
}
