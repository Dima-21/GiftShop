using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderStatusService : IService<OrderStatusDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public OrderStatusService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public OrderStatusDTO Add(OrderStatusDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderStatusDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderStatusDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderStatusDTO> GetAll()
        {
            IEnumerable<OrderStatus> status = dataManager.RepoOrderStatus.GetAll();
            IEnumerable<OrderStatusDTO> statusDTO = _mapper.Map<IEnumerable<OrderStatusDTO>>(status);
            foreach (var stat in statusDTO)
            {
                stat.Orders = null;
            }
            return statusDTO;
        }

        public OrderStatusDTO GetById(int id)
        {
            OrderStatus status = dataManager.RepoOrderStatus.Get(id);
            OrderStatusDTO statusDTO = _mapper.Map<OrderStatusDTO>(status);

            return statusDTO;
        }
    }
}
