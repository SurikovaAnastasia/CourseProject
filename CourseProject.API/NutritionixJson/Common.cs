using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.API.NutritionixJson
{
    [DataContract]
    public class Common
    {
        [DataMember(Name = "food_name")]
        public string FoodName { get; set; }

        [DataMember(Name = "serving_unit")]
        public string ServUnit { get; set; }

        [DataMember(Name = "serving_qty")]
        public double ServQty { get; set; }

        [DataMember(Name = "photo")]
        public Photo Photo { get; set; }

        [DataMember(Name = "tag_id")]
        public int Id { get; set; }
    }
}
