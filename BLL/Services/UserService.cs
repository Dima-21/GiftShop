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
    public class UserService : IServiceUsers<UserDTO>
    {
        private readonly IMapper _mapper;
        private readonly DataManager dataManager;

        public UserService(DataManager dataManager, IMapper _mapper)
        {
            this.dataManager = dataManager;
            this._mapper = _mapper;
        }

        public UserDTO Add(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(UserDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetById(string id)
        {
            AspNetUsers user = dataManager.RepoUsers.Find(x => x.Id.Equals(id))?.FirstOrDefault();
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }
    }
}
