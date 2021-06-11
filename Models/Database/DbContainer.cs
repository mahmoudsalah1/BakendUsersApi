using BackendUsers.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendUsers.Models;

namespace BackendUsers.Models.Database
{
    public class DbContainer : IdentityDbContext
    {
        public DbContainer(DbContextOptions<DbContainer> opts) : base(opts)
        {
        }

        public DbSet<PaymentDetails> PaymentDetails { get; set; }
        public DbSet<Department> Department { get; set; }
        //public DbSet<BackendUsers.Models.EmployeeVM> EmployeeVM { get; set; }
        public DbSet<Employee> Employee { get; set; }


    }
}
