using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Project
{
    public interface IProductRepo<T> where T: IProductEntity
    {
        T Get(int id);
        void Save(T entity);
        List<T> GetList();
        void Remove(int id);
    }
}
