using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackoverFlow.Web.Models
{
    public class Detalles
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public int Votes { get; set; }
        public DateTime CreationDate { get; set; }
        public string OwnerName { get; set; }
        public Guid OwnerId { get; set; }
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
    }
}