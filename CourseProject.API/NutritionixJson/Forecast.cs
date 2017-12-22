using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.API.NutritionixJson
{
    [DataContract]
    public class Forecast
    {
        [DataMember(Name = "branded")]
        public Brended[] Brended { get; set; }

        [DataMember(Name = "common")]
        public Common[] Common { get; set; }
    }
}
