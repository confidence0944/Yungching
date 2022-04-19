using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.DBEntities;
using Web.Models.Interface;

namespace Web.Models.Repository
{
    public class CategoryRepository : ICategoryRepositoty, IDisposable
    {
        private NorthwindContext db;

        public CategoryRepository(NorthwindContext _dbInstance)
        {
            db = _dbInstance;
        }

        public Category Get(int categoryID)
        {
            return db.Categories.FirstOrDefault(x => x.CategoryId == categoryID);
        }

        public IQueryable<Category> GetAll()
        {
            return db.Categories.OrderBy(x => x.CategoryId);
        }

        public void Create(Category instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                db.Categories.Add(instance);
                SaveChanges();
            }
        }

        public void Delete(Category instance)
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

        public void Update(Category instance)
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
    }
}
