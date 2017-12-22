using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DAL.Entities
{
    public class Food
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string NameOfFood { get; set; }
        public int Calories { get; set; }
    }
}
