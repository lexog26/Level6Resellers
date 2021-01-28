using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Purchases
{
    public class PurchaseInputDto : InputDto
    {
        [JsonProperty(PropertyName = "user")]
        public int UserCustomerId { get; set; }

        [JsonProperty(PropertyName = "reseller")]
        public int ResellerId { get; set; }

        [JsonProperty(PropertyName = "product")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "customer")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "prc")]
        public int ProductResellerCustomerId { get; set; }
    }
}
