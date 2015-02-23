using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverFlow.Domain.Entities;

namespace StackOverflow.Data
{
    public class StackOverflowContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
