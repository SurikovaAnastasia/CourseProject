using CourseProject.DAL.EF;
using CourseProject.DAL.Entities;
using CourseProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Repositories
{
    public class EFUnitOfWork :IUnitOfWork
    {
        private FoodContext db;
        private FoodRepository foodRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new FoodContext(connectionString);
        }
        public IRepository<Food> Foods
        {
            get
            {
                if (foodRepository == null)
                    foodRepository = new FoodRepository(db);
                return foodRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
