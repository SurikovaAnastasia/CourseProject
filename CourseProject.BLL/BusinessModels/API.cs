using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutritionix;

namespace CourseProject.BLL.BusinessModels
{
    public class API
    {
        const string APPID = "f65a723e";
        const string APPKEY = "9d41c312f1e0a67a39312489179c5880";

        public ObservableCollection<ResultOfSearch> SearchQuery(string query)
        {
             var nutritionix = new NutritionixClient();
             nutritionix.Initialize(APPID, APPKEY);

             var request = new SearchRequest { Query = query };
             SearchResponse response = nutritionix.SearchItems(request);

             ObservableCollection<ResultOfSearch> list = new ObservableCollection<ResultOfSearch>();
             ResultOfSearch listItem = new ResultOfSearch();
             foreach (SearchResult result in response.Results)
             {
                listItem.NameRS = result.Item.Name;
                if (result.Item.NutritionFact_Calories == null)
                {
                    listItem.CaloriesRS = "chlen";
                }
                else
                    listItem.CaloriesRS = result.Item.NutritionFact_Calories.Value.ToString();
                list.Add(listItem);
             }
             return list;
            //return response.Results;
        }

        //public Item Retrieve(string id)
        //{
        //    var nutritionix = new NutritionixClient();
        //    nutritionix.Initialize(APPID, APPKEY);

        //    return nutritionix.RetrieveItem(id);
        //}
    }

    public class ResultOfSearch
    {
        public string NameRS;
        public string CaloriesRS;
    }
}
