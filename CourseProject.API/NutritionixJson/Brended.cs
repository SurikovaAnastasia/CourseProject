using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.API.NutritionixJson
{
    [DataContract]
    public class Brended
    {
        [DataMember (Name = "food_name")]
        public string FoodName { get; set; }

        [DataMember(Name = "serving_unit")]
        public string ServUnit { get; set; }

        [DataMember(Name = "nix_brand_id")]
        public string BrandId { get; set; }

        [DataMember(Name = "brand_name_item_name")]
        public string BrandFoodName { get; set; }

        [DataMember(Name = "serving_qty")]
        public double ServQty { get; set; }

        [DataMember(Name = "nf_calories")]
        public string Calories { get; set; }

        [DataMember(Name = "photo")]
        public Photo Photo { get; set; }

        [DataMember(Name = "brand_name")]
        public string BrandName { get; set; }

        [DataMember(Name = "region")]
        public int Region { get; set; }

        [DataMember(Name = "brand_type")]
        public int BrandType { get; set; }

        [DataMember(Name = "nix_item_id")]
        public string ItemId { get; set; }
    }
}
