using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Companies
{
    public class CustomerCompanyDto : BaseDto<string>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "resellers")]
        public IEnumerable<int> ResellerIds { get; set; }

        [JsonProperty(PropertyName = "users")]
        public IEnumerable<int> UserIds { get; set; }

        [JsonProperty(PropertyName = "products")]
        public IEnumerable<int> ProductIds { get; set; }

        [JsonProperty(PropertyName = "purchases")]
        public IEnumerable<int> PurchaseIds { get; set; }
    }
}
