using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Companies
{
    public class ResellerCustomerDto : BaseDto<int>
    {
        [JsonProperty(PropertyName = "reseller_id")]
        public int ResellerCompanyId { get; set; }

        [JsonProperty(PropertyName = "customer_id")]
        public string CustomerCompanyId { get; set; }

    }
}
