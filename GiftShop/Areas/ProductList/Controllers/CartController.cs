﻿using BLL.Models;
using BLL.Services;
using GiftShop.Areas.ProductList.Models;
using GiftShop.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShop.Areas.ProductList.Controllers
{
    public class CartController : Controller
    {
        private IService<CartGoodsDTO> cartService;
        private IService<OrderDTO> orderService;
        private IService<OrderStatusDTO> orderStatusService;
        private IService<GoodsDTO> goodsService;
        private IServiceProvider services;
        UserManager<IdentityUser> _userManager;
        public CartController(IService<CartGoodsDTO> cartService,
                              IService<GoodsDTO> goodsService,
                              IService<OrderDTO> orderService,
                              IService<OrderStatusDTO> orderStatusService,
                              IServiceProvider services,
                              UserManager<IdentityUser> userManager)
        {
            this.cartService = cartService;
            this.orderService = orderService;
            this.orderStatusService = orderStatusService;
            this.goodsService = goodsService;
            this.services = services;
            this._userManager = userManager;
        }

        [Area("ProductList")]
        public IActionResult Index()
        {
            ShopCartViewModel cartVM = new ShopCartViewModel();
            cartVM.Cart = GetCart();
            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //string shopCartId = cart.ShopCardId;

            //cartVM.Cart = cartService.GetAll().Where(x => x.ShopCardId == shopCartId).ToList();
            return View(cartVM);
        }

        [Area("ProductList")]
        public IActionResult AddToCart(int goodsId)
        {
            GoodsDTO goods = goodsService.GetById(goodsId);

            ////Predicate<CartItemDTO> pr = new Predicate<CartItemDTO>();


            ////cartService.
            //if (goods != null)
            //{
            //    var cart = GetCart();
            //    cartService.Add(new CartItemDTO()
            //    {
            //        ShopCardId = cart.ShopCardId,
            //        Goods = goods,
            //        Amount = 1
            //    });
            //}

            if (Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart") == null)
            {
                List<CartGoodsDTO> cart = new List<CartGoodsDTO>();
                cart.Add(new CartGoodsDTO { Goods = goods, Amount = 1 });
                Infrastructure.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartGoodsDTO> cart = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");
                int index = isExist(goodsId);
                if (index != -1)
                {
                    cart[index].Amount++;
                }
                else
                {
                    cart.Add(new CartGoodsDTO { Goods = goods, Amount = 1 });
                }
                Infrastructure.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<CartGoodsDTO> cart = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Goods.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [Area("ProductList")]
        public IActionResult Remove(int goodsId)
        {
            List<CartGoodsDTO> cart = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");
            int index = isExist(goodsId);
            cart.RemoveAt(index);
            Infrastructure.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }



        public List<CartGoodsDTO> GetCart()
        {

            List<CartGoodsDTO> cart = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");
            return cart;
            //ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            //string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            //session.SetString("CartId", shopCartId);
            //string getshopCartId = session.GetString("CartId");
            //return new ShopCartDTO() { ShopCardId = shopCartId };

            //byte[] cartIdByte;
            //bool res = HttpContext.Session.TryGetValue("CartId", out cartIdByte);
            //byte[] shopCartId = (cartIdByte == null || cartIdByte.Length == 0) ? Encoding.ASCII.GetBytes(Guid.NewGuid().ToString()) : cartIdByte;
            //session.SetString("Cart", session.Id);
            //HttpContext.Session.Set("CartId", shopCartId);
            //return new ShopCartDTO() { ShopCardId = Encoding.ASCII.GetString(shopCartId) };
        }

        [Area("ProductList")]
        [HttpPost]
        public IActionResult Checkout(ShopCartViewModel cartVM)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account",
                    new
                    {
                        area = "Identity",
                        additionalInfoMessage = "Чтобы продолжить оформление заказа, необходимо авторизоваться!",
                        returnUrl = "~/ProductList/Cart/Checkout"
                    });
            }

            List<CartGoodsDTO> cartSession = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");
            cartSession.ForEach(x => x.Amount = cartVM.Cart.First(y => y.Id == x.Id).Amount);
            Infrastructure.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", cartSession);

            ShippingDetails shippingDetails = new ShippingDetails();

            if (cartSession != null)
                return View("Checkout", shippingDetails);

            return RedirectToAction("Index");
        }

        [Area("ProductList")]
        public IActionResult OrderConfirmation(ShippingDetails shippingDetails)
        {
            List<CartGoodsDTO> cart = Infrastructure.SessionExtensions.GetObjectFromJson<List<CartGoodsDTO>>(HttpContext.Session, "cart");

            List<OrderStatusDTO> statuses = orderStatusService.GetAll().ToList();

            OrderDTO order = new OrderDTO()
            {
                City = shippingDetails.City,
                Email = shippingDetails.Email,
                BranchNumber = shippingDetails.BranchNumber,
                Phone = shippingDetails.Phone,
                RecipientName = shippingDetails.RecipientName,
                OrderStatusId = statuses.First(x => x.StatusCode == 1).Id,
                Goods = cart,
                UserId = _userManager?.GetUserId(User)
            };

            OrderDTO resultAddOrder = orderService.Add(order);

            Infrastructure.SessionExtensions.SetObjectAsJson(HttpContext.Session, "cart", null);
            return View("CheckoutConfirmation", resultAddOrder.OrderNum);
            //return RedirectToAction("Index", "Goods");
        }

    }
}
