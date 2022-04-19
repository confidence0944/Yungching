using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.DBEntities;

namespace Web.Models.Interface
{
    public interface ICategoryRepositoty
    {
        Category Get(int productID);

        void Create(Category instance);

        void Update(Category instance);

        void Delete(Category instance);

        IQueryable<Category> GetAll();

        void SaveChanges();
    }
}
