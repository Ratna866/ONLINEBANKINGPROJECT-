using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Transactions;

namespace ONLINEBANKINGCASESTUDY1.Models
{
    public class onlinebankingDbContext:DbContext
    {
          
        public onlinebankingDbContext(DbContextOptions<onlinebankingDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        //public object User { get; internal set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<AccountDetails> accountDetails { get; set; }
        public DbSet<Transaction> transactions { get; set; }

    }
}

  