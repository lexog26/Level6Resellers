﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Users
{
    public class UserCustomerInputDto : InputDto
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "dni")]
        public string Dni { get; set; }

        [JsonProperty(PropertyName = "company_id")]
        public string CustomerCompanyId { get; set; }
    }
}
