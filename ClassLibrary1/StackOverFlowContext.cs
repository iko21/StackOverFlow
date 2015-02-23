using System.Data.Entity;
using StackOverFlow.Domain.Entities;

namespace StackOverFlow.Data
{
    public class StackOverFlowContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Account> Questions { get; set; }
        
    }
}
