using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Companies
{
    public class ResellerCompanyInputDto : InputDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
