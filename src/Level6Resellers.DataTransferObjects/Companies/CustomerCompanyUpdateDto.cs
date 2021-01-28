using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Companies
{
    public class CustomerCompanyUpdateDto : BaseDto<string>
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
