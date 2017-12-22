using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.BLL.DTO
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string NameOfFood { get; set; }
        public int Calories { get; set; }

        public string Query { get; set; }
    }
}
