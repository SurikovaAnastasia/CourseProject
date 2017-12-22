using CourseProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Food> Foods { get; }
        void Save();
    }
}
