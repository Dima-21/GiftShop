using System;
using System.Collections.Generic;
using System.Text;


namespace PresentationLayer.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        void Add(T item);
        void Delete(int id);
        void Edit(T item);
    }
}
