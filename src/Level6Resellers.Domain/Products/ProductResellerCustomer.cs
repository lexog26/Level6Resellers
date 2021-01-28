using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Products
{
    /// <summary>
    /// Represent triple relation between Customer companies, Reseller companies and its Products
    /// </summary>
    public class ProductResellerCustomer : Entity<int>
    {
        public int ProductId { get; set; }

        public int ResellerCustomerId { get; set; }

        public int ResellerId { get; set; }

        public string CustomerId { get; set; }

        public Product Product { get; set; }

        public ResellerCompany ResellerCompany { get; set; }

        public CustomerCompany CustomerCompany { get; set; }

        public ResellerCustomer ResellerCustomer { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
