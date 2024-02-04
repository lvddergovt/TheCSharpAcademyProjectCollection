using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using DrinksInfo.Models;
using DrinksInfo;
using System.Web;

namespace DrinksInfo
{
    public class DrinksService
    {

        public void GetCategories()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Content;
                var serialize = JsonConvert.DeserializeObject<Categories>(rawResponse);

                List<Category> returnedList = serialize.CategoriesList;

                TableVisualisationEngine tableVisualisationEngine = new();
                tableVisualisationEngine.ShowTable(returnedList, "Categories menu");
            }
        }


        public void GetDrinksByCategory(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.ExecuteAsync(request);

            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var serialize = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                List<Drink> returnedList = serialize.DrinksList;
                
                TableVisualisationEngine tableVisualisationEngine = new();
                tableVisualisationEngine.ShowTable(returnedList, "Drinks menu");
            }
        }
    }
}