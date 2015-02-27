using System.Configuration;
using System.Data.Entity;
using StackOverFlow.Domain.Entities;

namespace StackOverflow.Data
{
    public class StackOverflowContext:DbContext
    {

      
        public StackOverflowContext() : base(ConnectionString.get()) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Question> Questions { get; set; }
    }

    public static class ConnectionString
    {
        public static string get()
        {
            var Environment = ConfigurationManager.AppSettings["Environment"];
            return string.Format("name={0}", Environment);
        }
    }
}