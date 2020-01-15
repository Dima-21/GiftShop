using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    public class GroupRepository : IRepository<Group>
    {
        GiftShopContext context = new GiftShopContext();
        ~GroupRepository()
        {
            context.Dispose();
        }
        public void Create(Group item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            return context.Group;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Group item)
        {
            throw new NotImplementedException();
        }
    }
}
