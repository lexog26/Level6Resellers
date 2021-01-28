using Level6Resellers.Domain.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Products
{
    public class Product : Entity<int>
    {
        public string Name { get; set; }

        public float Price { get; set; }

        //public IEnumerable<ProductReseller> ProductResellers { get; set; }

        public IEnumerable<ProductResellerCustomer> ProductResellerCustomers { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
