using CourseProject.DAL.EF;
using CourseProject.DAL.Entities;
using CourseProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Repositories
{
    public class FoodRepository : IRepository<Food>
    {
        private FoodContext db;
        public FoodRepository(FoodContext context)
        {
            this.db = context;
        }
        IEnumerable<Food> IRepository<Food>.GetAll()
        {
            return db.Foods;
        }
        public Food Get(DateTime date)
        {
            return db.Foods.Find(date);
        }
        public void Create(Food a)
        {
            db.Foods.Add(a);
        }
        public void Update(Food a)
        {
            db.Entry(a).State = EntityState.Modified;
        }
        public IEnumerable<Food> Find(Func<Food, Boolean> predicate)
        {
            return db.Foods.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Food a = db.Foods.Find(id);
            if (a != null)
                db.Foods.Remove(a);
        }
    }
}
