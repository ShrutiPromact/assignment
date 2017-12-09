using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CustomInfo.Models;

namespace CustomInfo.DAL
{
    public class CustomerInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CustomerContext>
    {
        protected override void Seed(CustomerContext context)
        {
            var customers = new List<Customer>
            {
            new Customer{CustomerName="Carson",City="pune"},
             new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                new Customer{CustomerName="Carson",City="pune"},
                 new Customer{CustomerName="Carson",City="pune"},
                  new Customer{CustomerName="Carson",City="pune"},
                  new Customer{CustomerName="Carson",City="pune"},

            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
           
        }



    }
}