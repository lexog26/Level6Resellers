using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Products
{
    public class ProductDto : BaseDto<int>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }

        [JsonProperty(PropertyName = "resellers")]
        public IEnumerable<int> ResellerIds { get; set; }

        [JsonProperty(PropertyName = "customers")]
        public IEnumerable<int> CustomerIds { get; set; }

    }
}
