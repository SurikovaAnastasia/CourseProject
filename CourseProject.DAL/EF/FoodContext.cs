using CourseProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.EF
{
    public class FoodContext : DbContext
    {
        public DbSet<Food> Foods { get; set; }
        static FoodContext()
        {
            Database.SetInitializer<FoodContext>(new StoreDbInitializer());
        }
        public FoodContext(string connectionString) : base(connectionString)
        {
        }
    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<FoodContext>
    {
        protected override void Seed(FoodContext db)
        {
            db.SaveChanges();
        }
    }
}
