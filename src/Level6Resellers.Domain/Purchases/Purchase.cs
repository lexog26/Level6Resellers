using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Products;
using Level6Resellers.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Purchases
{
    /// <summary>
    /// Relation between Customer companies's users and ProductResellerCustomer relation
    /// </summary>
    public class Purchase : Entity<int>
    {
        public int UserCustomerId { get; set; }

        public int ResellerId { get; set; }

        public int ProductId { get; set; }

        public string CustomerId { get; set; }

        public int ProductResellerCustomerId { get; set; }

        public UserCustomer UserCustomer { get; set; }

        public ResellerCompany ResellerCompany { get; set; }

        public Product Product { get; set; }

        public CustomerCompany CustomerCompany { get; set; }

        public ProductResellerCustomer ProductResellerCustomer { get; set; }

        public DateTime PurchaseDate
        {
            get
            {
                return CreatedDate;
            }
        }
        
    }
}
