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

        public PropertyDTO Add(PropertyDTO item)
        {
            Property prop = _mapper.Map<Property>(item);
            dataManager.RepoProperty.Create(prop);
            dataManager.RepoProperty.Save();
            return _mapper.Map<PropertyDTO>(prop);
        }

        public void Delete(int id)
        {
            try
            {
                dataManager.RepoProperty.Delete(id);
                dataManager.RepoProperty.Save();
            }
            catch
            {
            }
        }

        public void Delete(PropertyDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(PropertyDTO item)
        {
            Property prop = _mapper.Map<Property>(item);
            dataManager.RepoProperty.Update(prop);
            dataManager.RepoProperty.Save();
        }

        public IEnumerable<PropertyDTO> GetAll()
        {
            try
            {
                List<Property> properties = dataManager.RepoProperty.GetAll().ToList();
                List<PropertyDTO> result = _mapper.Map<List<PropertyDTO>>(properties);
                foreach (var prop in result)
                {
                    prop.Charact = prop.Charact.Where(x => !string.IsNullOrEmpty(x.Value)).ToList();
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public PropertyDTO GetById(int id)
        {
            Property order = dataManager.RepoProperty.Get(id);
            PropertyDTO result = _mapper.Map<PropertyDTO>(order);

            return result;
        }
    }
}
