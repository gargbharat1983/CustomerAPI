using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models
{
    public class CustomerDBContext : DbContext
    {
        public CustomerDBContext (DbContextOptions<CustomerDBContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerAPI.Models.Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerAPI.Models.Customer>().HasData(new CustomerAPI.Models.Customer
            {
                Id = 1,
                FirstName = "Uncle",
                LastName = "Bob",
                Phone= "999-888-7777"

            }, new CustomerAPI.Models.Customer
            {
                Id = 2,
                FirstName = "Jan",
                LastName = "Kirsten",
                Phone= "111-222-3333"
            });
        }
    }
}
