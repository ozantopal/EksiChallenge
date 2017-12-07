using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksiChallenge.CrossCutting.Common.Models
{
    /// <summary>
    /// BreweryDb servisinden gelen üretici nesnesi.
    /// </summary>
    public class Brewery : BaseEntity
    {
        //[JsonProperty(PropertyName = "id")]
        //public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nameShortDisplay")]
        public string NameShortDisplay { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "website")]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "established")]
        public string Established { get; set; }

        [JsonProperty(PropertyName = "isOrganic")]
        public string IsOrganic { get; set; }

        [JsonProperty(PropertyName = "images")]
        public Images Images { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "statusDisplay")]
        public string StatusDisplay { get; set; }

        [JsonProperty(PropertyName = "createDate")]
        public string CreateDate { get; set; }

        [JsonProperty(PropertyName = "updateDate")]
        public string UpdateDate { get; set; }

        [JsonProperty(PropertyName = "isMassOwned")]
        public string IsMassOwned { get; set; }

        [JsonProperty(PropertyName = "brandClassification")]
        public string BrandClassification { get; set; }

        [JsonProperty(PropertyName = "mailingListUrl")]
        public string MailingListUrl { get; set; }
    }
}
