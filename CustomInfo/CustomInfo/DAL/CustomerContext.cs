using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomInfo.Models;
using System.Data.Entity;


namespace CustomInfo.DAL
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("CustomerContext")
        {
        }


        public DbSet<Customer> Customers { get; set; }
    }

              
}