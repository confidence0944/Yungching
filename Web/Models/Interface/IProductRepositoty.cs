using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DBEntities;

namespace Web.Models.Interface
{
    public interface IProductRepositoty
    {
        Product Get(int productID);

        void Create(Product instance);

        void Update(Product instance);

        void Delete(Product instance);

        IQueryable<Product> GetAll();

        void SaveChanges();
    }
}
