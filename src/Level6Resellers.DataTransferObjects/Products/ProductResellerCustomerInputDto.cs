﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.DataTransferObjects.Products
{
    public class ProductResellerCustomerInputDto : InputDto
    {
        public int ProductId { get; set; }

        public int ResellerId { get; set; }

        public int ResellerCustomerId { get; set; }

        public string CustomerId { get; set; }
    }
}
