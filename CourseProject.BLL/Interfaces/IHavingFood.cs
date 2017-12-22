using CourseProject.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BLL.Interfaces
{
    public interface IHavingFood
    {
        void HaveFood(FoodDTO foodDTO);
        FoodDTO GetFood(DateTime date);
        IEnumerable<FoodDTO> GetFoods();
        void Dispose();
    }
}
