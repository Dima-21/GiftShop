using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.Services
{
    public interface IServiceUsers<T> : IService<T>
    {
        T GetById(string id);
    }
}
