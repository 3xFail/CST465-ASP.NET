using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public interface ICategoryRepo<T> where T: ICategoryEntity
    {
        T Get(int id);
        void Save(T entity);
        List<T> GetList();
    }
}