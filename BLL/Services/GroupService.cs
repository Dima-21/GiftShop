﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;

namespace BLL.Services
{
    public class GroupService : IService<GroupDTO>
    {
        IRepository<Group> repo;

        public GroupService(IRepository<Group> repo)
        {
            this.repo = repo;
        }

        public void Add(GroupDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(GroupDTO item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupDTO> GetAll()
        {
            //List<Group> result = repo.GetAll().ToList();
            //Mapper m = new Mapper()
            //m.Map(result, List<Group>, List<GroupDTO>);
            List<GroupDTO> result = repo.GetAll().Select(x => new GroupDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return result;
        }
    }
}