using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Companies
{
    public class ResellerCompanyDto : BaseDto<int>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public IEnumerable<string> CustomerIds { get; set; }

        [JsonProperty(PropertyName = "products")]
        public IEnumerable<int> ProductIds { get; set; }

    }
}
