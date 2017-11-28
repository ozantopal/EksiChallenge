using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.Common.Models
{
    /// <summary>
    /// BreweryDb servisinden gelen Brewery nesnesine ait Image nesnesi.
    /// </summary>
    public class Images
    {
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }

        [JsonProperty(PropertyName = "medium")]
        public string Medium { get; set; }

        [JsonProperty(PropertyName = "large")]
        public string Large { get; set; }

        [JsonProperty(PropertyName = "squareMedium")]
        public string SquareMedium { get; set; }

        [JsonProperty(PropertyName = "squareLarge")]
        public string SquareLarge { get; set; }
    }
}
