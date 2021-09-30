using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Add(T item);
        void Delete(int id);
        void Delete(T item);
        void Edit(T item);
        T GetById(int id);
    }
}
