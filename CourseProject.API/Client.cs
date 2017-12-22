using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourseProject.API.NutritionixJson;
using Nutritionix;

namespace CourseProject.API
{
    public class Client
    {
        const string APPID = "f65a723e";
        const string APPKEY = "9d41c312f1e0a67a39312489179c5880";
        //const int TIMEOUT = 5;

        public SearchResult[] Search(string query)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(APPID, APPKEY);

            var request = new SearchRequest { Query = query };
            SearchResponse response = nutritionix.SearchItems(request);

            return response.Results;
        }

        public Item Retrieve(string id)
        {
            var nutritionix = new NutritionixClient();
            nutritionix.Initialize(APPID, APPKEY);

            return nutritionix.RetrieveItem(id);
        }

    //    static void Res(string arg)
    //    {
    //        if (String.IsNullOrWhiteSpace(arg))
    //            throw new ArgumentNullException("No parameters");
    //        using (HttpClient client = new HttpClient())
    //        {
    //            var request = $"https://api.nutritionix.com/v1_1/search/{arg}?fields=item_name,brand_name,nf_calories&appId={APPID}&appKey={APPKEY}";
    //            //log
    //            Uri uri;
    //            if (!Uri.TryCreate(request, UriKind.Absolute, out uri))
    //                throw new InvalidDataException("Coudn't create URI");
    //            var tRequest = client.GetAsync(uri, HttpCompletionOption.ResponseContentRead);
    //            var timeSpent = 0;
    //            while (tRequest.Status != TaskStatus.RanToCompletion && tRequest.Status != TaskStatus.Faulted
    //                && timeSpent < TIMEOUT)
    //            {
    //                timeSpent++;
    //                Thread.Sleep(1000);
    //            }
    //            tRequest.ContinueWith((r) => 
    //            {
    //                if (!r.IsCompleted)
    //                    throw new InvalidOperationException();
    //                var result = r.Result;
    //                if (result == null)
    //                    throw new InvalidOperationException("Can't reach server");
    //                if (result.StatusCode != System.Net.HttpStatusCode.OK)
    //                {
    //                    //tut budet log
    //                    throw new InvalidOperationException("Can't process request");
    //                }
    //                try
    //                {
    //                    var tProcess = result.Content.ReadAsStreamAsync();
    //                    tProcess.ContinueWith((rProc) => 
    //                    {
    //                        using (var str = rProc.Result)
    //                        {
    //                            DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(Forecast));
    //                            var o = s.ReadObject(str) as Forecast;
    //                            //log
    //                            return o;
    //                        }
    //                    });
    //                }
    //                catch (Exception ex)
    //                {
    //                    //log
    //                    throw;
    //                }
                    
    //            });
    //        }
    //    }
    }
}
