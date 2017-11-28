using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Common.Models
{
    /// <summary>
    /// BreweryDb servisinden gelen responsea ait root object.
    /// </summary>
    public class ServiceResponse
    {
        [JsonProperty(PropertyName = "currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(PropertyName = "numberOfPages")]
        public int TotalPage { get; set; }

        [JsonProperty(PropertyName = "totalResults")]
        public int totalResults { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<Brewery> Breweries { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
