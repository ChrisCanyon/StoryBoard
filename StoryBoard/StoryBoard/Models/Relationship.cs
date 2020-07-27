using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Relationship
    {
        public int Id { get; set; }
        public int RelationshipType { get; set; }
        public int? Reputation { get; set; }
        public int FromCharacter { get; set; }
        public int ToCharacter { get; set; }

        public virtual StoryCharacter FromCharacterNavigation { get; set; }
        public virtual RelationshipTypeLookup RelationshipTypeNavigation { get; set; }
        public virtual StoryCharacter ToCharacterNavigation { get; set; }
    }
}
