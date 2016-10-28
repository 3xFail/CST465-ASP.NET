using ASP.Net_Project;
using System.Collections.Generic;

namespace ASP.NET_Project
{
    public interface IDataEntityRepository<T> where T : IDataEntity
    {
        T Get(int id);
        void Save(T entity);
        List<T> GetList();
    }
}