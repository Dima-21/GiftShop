using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    class CharactRepository : IRepository<Charact>
    {
        GiftShopContext context = new GiftShopContext();

        ~CharactRepository()
        {
            context.Dispose();
        }
        public void Create(Charact item)
        {
            context.Charact.Add(item);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Charact Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Charact> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Charact item)
        {
            throw new NotImplementedException();
        }
    }
}
