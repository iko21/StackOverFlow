using System;

namespace StackOverFlow.Domain.Entities
{
    public class Question : IEntity
    {
        public Guid Id { get; private set; }

        public Question()
        {
            Id = Guid.NewGuid();
        }

        public int Votes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual Guid OwnerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate {get; set;}

       
    }
}