using Newtonsoft.Json;
using System;

namespace Level6Resellers.DataTransferObjects
{
    public class BaseDto<T>
    {
        [JsonProperty(PropertyName = "id")]
        public T Id { get; set; }
    }
}
