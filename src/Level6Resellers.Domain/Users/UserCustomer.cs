using Level6Resellers.Domain.Companies;
using Level6Resellers.Domain.Purchases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level6Resellers.Domain.Users
{
    public class UserCustomer : Entity<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Dni { get; set; }

        public string CustomerCompanyId { get; set; }

        public CustomerCompany CustomerCompany { get; set; }

        public IEnumerable<Purchase> Purchases { get; set; }
    }
}
