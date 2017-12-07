using EksiChallenge.CrossCutting.Common.Models;
using EksiChallenge.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Repositories.BreweryDbServiceRepository
{
    public class BreweryRepository : IRepository<Brewery>
    {
        private readonly string apiKey;
        private readonly string baseUrl;

        public BreweryRepository(string baseUrl, string apiKey)
        {
            this.apiKey = apiKey;
            this.baseUrl = baseUrl;
        }

        private async Task<RepositoryResponse> CallApi(string url)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            HttpResponseMessage response = await client.GetAsync(url);
            string rawData = await response.Content.ReadAsStringAsync();
            RepositoryResponse result = JsonConvert.DeserializeObject<RepositoryResponse>(rawData);

            return result;
        }

        private string GetQuerySuffix(ServiceParameter serviceParameter)
        {
            // BreweryDb'nin 4 karakterin altını kabul etmemesinden
            // ötürü searchQuery'nin sonuna gerekli sayıda wildcard(*)
            // eklemesi yapılmıştır.
            string result = String.Empty;

            if (serviceParameter.SearchName.Length < 4)
            {
                int countOfAsterisk = 4 - serviceParameter.SearchName.Length;
                result = String.Format("&name={0}{1}", serviceParameter.SearchName, new String('*', countOfAsterisk));
            }
            else
            {
                result = String.Format("&name={0}", String.Concat(serviceParameter.SearchName, "*"));
            }

            if (!serviceParameter.IsAscending)
            {
                result = String.Concat(result, "&sort=DESC");
            }

            if (serviceParameter.PageNumber != 0)
            {
                result = String.Concat(result, String.Concat("&p=", serviceParameter.PageNumber));
            }

            result = String.Concat(result, String.Concat("&order=", serviceParameter.OrderParam));


            return result;
        }

        public async Task<ServiceResponse<Brewery>> Get(ServiceParameter serviceParameter)
        {
            string querySuffix = GetQuerySuffix(serviceParameter);
            string requestUrl = requestUrl = String.Format("{0}?key={1}{2}", baseUrl, apiKey, querySuffix);
            RepositoryResponse rawData = await CallApi(requestUrl);
            ServiceResponse<Brewery> result = new ServiceResponse<Brewery>
            {
                CurrentPage = rawData.CurrentPage,
                TotalPage = rawData.TotalPage,
                Data = rawData.Breweries
            };

            return result;
        }
    }
}
