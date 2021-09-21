using AutoMapper;
using BLL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class PropertyService : IService<PropertyDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public PropertyService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public void Add(PropertyDTO item)
        {
            //Goods goods = _mapper.Map<Goods>(item);
            //dataManager.RepoGoods.Create(goods);
            //dataManager.RepoGoods.Save();
        }

        public void Delete(int id)
        {
            //dataManager.RepoGoods.Delete(id);
            //dataManager.RepoGoods.Save();
        }

        public void Edit(PropertyDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertyDTO> GetAll()
        {
            IEnumerable<Property> properties = dataManager.RepoProperty.GetAll();
            List<PropertyDTO> result = _mapper.Map<List<PropertyDTO>>(properties);
            return result;
        }

        public PropertyDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
