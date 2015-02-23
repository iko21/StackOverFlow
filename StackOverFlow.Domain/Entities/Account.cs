using System;

namespace StackOverFlow.Domain.Entities
{
   public class Account : IEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
        }
    }
}