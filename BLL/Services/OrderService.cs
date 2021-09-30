using AutoMapper;
using BLL.Infrastructure;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class OrderService : IService<OrderDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public OrderService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public OrderDTO Add(OrderDTO item)
        {

            Order order = _mapper.Map<Order>(item);
            dataManager.RepoOrder.Create(order);

            dataManager.RepoOrder.Save();

            order.OrderNum = order.Id + 1000;

            dataManager.RepoOrder.Update(order);
            dataManager.RepoOrder.Save();
            var filteredGoods = dataManager.RepoOrderGoods.Find(x => x.OrderId == order.Id);
            List<Goods> orderedGoods = filteredGoods.Select(x => x.Goods).ToList();

            StringBuilder message = new StringBuilder();
            message.Append($"Заказ № { order.OrderNum}");
            foreach (Goods goods in orderedGoods)
            {
                message.Append(Environment.NewLine);
                message.Append(goods.Name + " - " + goods.Price + " грн");
            }
            message.Append(Environment.NewLine);
            if (order.Email != null)
            {
                MailSender sender = new MailSender(new System.Net.Mail.MailAddress(order.Email));
                sender.SendEmailAsync($"GiftShop - Заказ №{order.OrderNum}",
                    message.ToString());
            }

            return _mapper.Map<OrderDTO>(order); ;
        }

        public void Delete(int id)
        {
            dataManager.RepoOrder.Delete(id);
            dataManager.RepoOrder.Save();
        }

        public void Delete(OrderDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderDTO item)
        {
            Order order = _mapper.Map<Order>(item);

            foreach (var goods in order.OrderGoods)
            {
                //goods.Goods = new Goods()
                //{
                //    Id = goods.GoodsId
                //};
                goods.OrderId = order.Id;
            }

            dataManager.RepoOrder.Update(order);
            dataManager.RepoOrder.Save();
        }

        public virtual IEnumerable<OrderDTO> GetAll()
        {
            List<Order> order = dataManager.RepoOrder.GetAll().ToList();
            List<OrderDTO> result = _mapper.Map<List<OrderDTO>>(order);

            return result;
        }

        public OrderDTO GetById(int id)
        {
            Order order = dataManager.RepoOrder.Get(id);
            OrderDTO result = _mapper.Map<OrderDTO>(order);

            return result;
        }
    }


}
