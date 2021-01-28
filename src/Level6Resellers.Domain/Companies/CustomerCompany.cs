using Level6Resellers.Domain.Products;
using Level6Resellers.Domain.Purchases;
using Level6Resellers.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Companies
{
    public class CustomerCompany : Entity<string>
    {
        public CustomerCompany()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public IEnumerable<ResellerCustomer> ResellerCustomers { get; set; }

        public IEnumerable<UserCustomer> Users { get; set; }

        public IEnumerable<ProductResellerCustomer> ProductResellerCustomers { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
