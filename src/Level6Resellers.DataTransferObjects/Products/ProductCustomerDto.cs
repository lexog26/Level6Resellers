using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Products
{
    public class ProductCustomerDto : BaseDto<int>
    {
        [JsonProperty(PropertyName = "product")]
        public int ProductId { get; set; }

        [JsonProperty(PropertyName = "customer")]
        public string CustomerId { get; set; }
    }
}
