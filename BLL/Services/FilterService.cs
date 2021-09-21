using AutoMapper;
using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    class FilterService : IService<PropertyDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;
        public FilterService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }
        public void Add(PropertyDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
