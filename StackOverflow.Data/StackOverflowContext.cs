using System.Data.Entity;
using StackOverFlow.Domain.Entities;

namespace StackOverflow.Data
{
    public class StackOverflowContext:DbContext
    {
    //    public StackOverflowContext() : base("context") { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}