using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class RelationshipTypeLookup
    {
        public RelationshipTypeLookup()
        {
            Relationship = new HashSet<Relationship>();
        }

        public int Id { get; set; }
        public string RelationshipDesciption { get; set; }
        public int ReputationThreshold { get; set; }

        public virtual ICollection<Relationship> Relationship { get; set; }
    }
}
