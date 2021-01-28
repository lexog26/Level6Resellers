using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Purchases
{
    public class PurchaseInputDto
    {
        [JsonProperty(PropertyName = "user_id")]
        public int UserCustomerId { get; set; }

        [JsonProperty(PropertyName = "reseller_id")]
        public int ResellerId { get; set; }

        [JsonProperty(PropertyName = "product_id")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "customer_id")]
        public string CustomerId { get; set; }
    }
}
