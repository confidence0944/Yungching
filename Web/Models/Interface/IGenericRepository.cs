using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int productID);

        void Create(T instance);

        void Update(T instance);

        void Delete(T instance);

        IQueryable<T> GetAll();

        void SaveChanges();
    }
}
