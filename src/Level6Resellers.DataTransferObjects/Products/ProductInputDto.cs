using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Products
{
    public class ProductInputDto : InputDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "price")]
        public float Price { get; set; }
    }
}
