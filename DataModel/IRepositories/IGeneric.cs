using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.IRepositories
{
    public interface IGeneric<T>
    {
        T RetriveById(int id);
        List<T> RetriveAll();
        T Create(T entity);
        T Patch(T entity);
        bool Delete(int id);

    }
}
