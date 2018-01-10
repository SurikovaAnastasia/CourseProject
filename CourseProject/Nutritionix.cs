using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutritionix;

namespace CourseProject
{
    public class API
    {
        const string APPID = "f65a723e";
        const string APPKEY = "9d41c312f1e0a67a39312489179c5880";

        public ObservableCollection<ResultOfSearch> SearchQuery(string query)
        {
            try
            {
                var nutritionix = new NutritionixClient();
                nutritionix.Initialize(APPID, APPKEY);

                var request = new SearchRequest { Query = query };
                SearchResponse response = nutritionix.SearchItems(request);

                ObservableCollection<ResultOfSearch> list = new ObservableCollection<ResultOfSearch>();
                ResultOfSearch listItem = new ResultOfSearch();
                foreach (SearchResult result in response.Results)
                {
                    listItem.IdRS = result.Item.Id;
                    listItem.NameRS = result.Item.Name;
                    listItem.BrandRS = result.Item.BrandName;
                    listItem.CaloriesRS = nutritionix.RetrieveItem(listItem.IdRS).NutritionFact_Calories;
                    list.Add(listItem);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new NutritionixException("Getting API error");
            }
        }
    }

    public struct ResultOfSearch
    {
        public string NameRS;
        public decimal? CaloriesRS;
        public string IdRS;
        public string BrandRS;
    }
}