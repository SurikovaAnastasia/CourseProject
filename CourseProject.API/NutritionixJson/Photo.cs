using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.API.NutritionixJson
{
    [DataContract]
    public class Photo
    {
        [DataMember(Name = "thumb")]
        public string Thumb { get; set; }

        [DataMember(Name = "highres")]
        public int Highres { get; set; }
    }
}
