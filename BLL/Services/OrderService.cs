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

        public void Add(OrderDTO item)
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


        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderDTO item)
        {
            Order order = _mapper.Map<Order>(item);

            dataManager.RepoOrder.Update(order);
            dataManager.RepoOrder.Save();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
