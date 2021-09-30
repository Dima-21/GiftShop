using AutoMapper;
using BLL.Models;
using BLL.Services;
using GiftShop.Areas.StoreManage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShop.Areas.StoreManage.Controllers
{
    [Area("StoreManage")]
    [Authorize(Roles = "Админ, Модератор")]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<OrderDTO> orderService;
        private readonly IService<OrderGoodsDTO> orderGoodsService;
        private readonly IService<OrderStatusDTO> orderStatusService;


        public OrderController(IService<OrderDTO> orderService,
                               IService<OrderGoodsDTO> orderGoodsService,
                               IService<OrderStatusDTO> orderStatusService,
                               IMapper mapper)
        {
            this._mapper = mapper;
            this.orderService = orderService;
            this.orderGoodsService = orderGoodsService;
            this.orderStatusService = orderStatusService;
        }
        // GET: OrderController
        public ActionResult Index(int? statusId = null)
        {
            OrderListViewModel orderVM = new OrderListViewModel();

            orderVM.OrderStatusList = orderStatusService.GetAll().ToList();
            //model.Order = orderService.GetAll().ToList();

            if (orderVM.OrderStatusList != null)
            {
                if (statusId != null)
                {
                    orderVM.SelectedStatus = orderVM.OrderStatusList.First(x => x.Id == statusId);

                }
                else
                {
                    orderVM.SelectedStatus = orderVM.OrderStatusList.FirstOrDefault();

                }
                OrderStatusDTO statusById = orderStatusService.GetById((int)orderVM.SelectedStatus.Id);
                orderVM.Orders = statusById.Orders.Select(x => new ListWithSelectOrderViewModel { Order = x }).ToList();
            }
            return View(orderVM);
        }


        // GET: OrderController/Edit/5
        public ActionResult ConfirmOrder(int id)
        {
            OrderDetailsViewModel orderVM = new OrderDetailsViewModel();

            orderVM.Order = orderService.GetById(id);

            return View(orderVM);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrder(OrderDetailsViewModel orderVM)
        {
            try
            {
                // Меняем статус заказа на "Подтверждён"
                List<OrderStatusDTO> listOfStatuses = orderStatusService.GetAll().ToList();
                OrderStatusDTO statusConfirm = listOfStatuses.FirstOrDefault(x => x.StatusCode == 2);
                orderVM.Order.OrderStatusId = statusConfirm.Id;

                orderService.Edit(orderVM.Order);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult DeleteOrder(int orderId)
        {
            try
            {
                orderService.Delete(orderId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(ConfirmOrder), new { id = orderId });
            }
        }

        public ActionResult DeleteGoodsInOrder(int orderId, int goodsId)
        {

            try
            {
                orderGoodsService.Delete(new OrderGoodsDTO
                {
                    OrderId = orderId,
                    GoodsId = goodsId
                });
                return RedirectToAction(nameof(ConfirmOrder), new { id = orderId });
            }
            catch
            {
                return RedirectToAction(nameof(ConfirmOrder), new { id = orderId });
            }
        }

        public ActionResult ChangeOrderStatus(OrderListViewModel orderVM, short statusId)
        {
           
            try
            {
                List<OrderDTO> checkedOrders = orderVM.Orders.Where(x => x.AreChecked).Select(x => x.Order).ToList();
                foreach (OrderDTO checkedOrder in checkedOrders)
                {
                    OrderDTO order = orderService.GetById(checkedOrder.Id);
                    order.OrderStatusId = statusId;
                    orderService.Edit(order);
                }
                return RedirectToAction(nameof(Index), new { statusId = orderVM.SelectedStatus.Id });
            }
            catch
            {
                return RedirectToAction(nameof(Index), new { statusId = orderVM.SelectedStatus.Id });
            }
        }


        // POST: OrderController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteOrder(int orderId)
        //{
        //    try
        //    {
        //        orderService.Delete(id);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
