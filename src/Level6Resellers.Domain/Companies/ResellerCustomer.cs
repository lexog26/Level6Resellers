using Level6Resellers.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Companies
{
    public class ResellerCustomer : Entity<int>
    {
        public int ResellerCompanyId { get; set; }

        public string CustomerCompanyId { get; set; }

        public ResellerCompany ResellerCompany { get; set; }

        public CustomerCompany CustomerCompany { get; set; }

        public IEnumerable<ProductResellerCustomer> ProductResellerCustomers { get; set; }
    }
}
