using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.DBEntities;
using Web.Models.Interface;

namespace Web.Models.Repository
{
    public class ProductRepository : IProductRepositoty, IDisposable
    {
        private NorthwindContext db;

        public ProductRepository()
        {
            db = new NorthwindContext();
        }

        public Product Get(int productID)
        {
            return db.Products.FirstOrDefault(x => x.ProductId == productID);
        }

        public IQueryable<Product> GetAll()
        {
            return db.Products.OrderBy(x => x.ProductId);
        }

        public void Create(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Products.Add(instance);
                SaveChanges();
            }
        }

        public void Delete(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Deleted;
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Update(Product instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Entry(instance).State = EntityState.Modified;
                SaveChanges();
            }
        }


        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
                db = null;
            }
        }
    }
}
