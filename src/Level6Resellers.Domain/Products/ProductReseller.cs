using Level6Resellers.Domain.Companies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Products
{
    public class ProductReseller : Entity<int>
    {
        public int ResellerId { get; set; }

        public int ProductId { get; set; }

        public ResellerCompany ResellerCompany { get; set; }

        public Product Product { get; set; }
    }
}
