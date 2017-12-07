using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Core.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Services.Services
{
    public class BreweryService : IBreweryService
    {
        private async Task<RepositoryResponse> CallApi(string url)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage response = await client.GetAsync(url);
            string rawData = await response.Content.ReadAsStringAsync();
            RepositoryResponse result = JsonConvert.DeserializeObject<RepositoryResponse>(rawData);

            return result;
        }

        private string GetQuerySuffix(string searchName, bool isAscending, int pageNumber)
        {
            // BreweryDb'nin 4 karakterin altını kabul etmemesinden
            // ötürü searchQuery'nin sonuna gerekli sayıda wildcard(*)
            // eklemesi yapılmıştır.
            string result = String.Empty;

            if (searchName.Length < 4)
            {
                int countOfAmpersand = 4 - searchName.Length;
                result = String.Format("&name={0}{1}", searchName, new String('*', countOfAmpersand));
            }
            else
            {
                result = String.Format("&name={0}", String.Concat(searchName, "*"));
            }

            if (!isAscending)
            {
                result = String.Concat(result, "&sort=DESC");
            }

            if (pageNumber != 0)
            {
                result = String.Concat(result, String.Concat("&p=", pageNumber));
            }

            return result;
        }


        public async Task<ServiceResponse> GetBreweries(string apiKey,
                                                        string searchName = "",
                                                        bool isAscending = true,
                                                        int pageNumber = 1)
        {
            string querySuffix = GetQuerySuffix(searchName, isAscending, pageNumber);

            string requestUrl = requestUrl = String.Format("http://api.brewerydb.com/v2/breweries?key={0}{1}", apiKey, querySuffix);
            ServiceResponse result = await CallApi(requestUrl);

            return result;
        }
    }
}
