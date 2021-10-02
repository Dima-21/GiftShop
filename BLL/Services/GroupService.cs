using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using BLL.Models;
using BLL.Services;
using DAL.Repositories;
using BLL.Infrastructure;
using AutoMapper;

namespace BLL.Services
{
    public class GroupService : IService<GroupDTO>
    {
        private readonly DataManager dataManager;
        private readonly IMapper _mapper;

        public GroupService(DataManager dataManager, IMapper mapper)
        {
            this.dataManager = dataManager;
            this._mapper = mapper;
        }

        public GroupDTO Add(GroupDTO item)
        {
            Group group = _mapper.Map<Group>(item);

            dataManager.RepoGroup.Create(group);
            dataManager.RepoGroup.Save();

            return _mapper.Map<GroupDTO>(group);
        }

        public void Delete(int id)
        {
            dataManager.RepoGroup.Delete(id);
            dataManager.RepoGroup.Save();

        }

        public void Delete(GroupDTO item)
        {
            throw new NotImplementedException();
        }

        public void Edit(GroupDTO item)
        {
            Group group = _mapper.Map<Group>(item);

            dataManager.RepoGroup.Update(group);
            dataManager.RepoGroup.Save();
        }

        public IEnumerable<GroupDTO> GetAll()
        {
            IEnumerable<Group> group = dataManager.RepoGroup.GetAll();
            List<GroupDTO> groupDTO = _mapper.Map<List<GroupDTO>>(group);
            //Mapper m = new Mapper()
            //m.Map(result, List<Group>, List<GroupDTO>);


            //List<GroupDTO> result = dataManager.RepoGroup.GetAll().Select(x => new GroupDTO
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Icon = x.Icon, 
            //    Image = x.Image
            //}).ToList();
            
            return groupDTO;
        }

        public GroupDTO GetById(int id)
        {
            Group group = dataManager.RepoGroup.Get(id);
            GroupDTO groupDTO = _mapper.Map<GroupDTO>(group);
            return groupDTO;
        }
    }
}
