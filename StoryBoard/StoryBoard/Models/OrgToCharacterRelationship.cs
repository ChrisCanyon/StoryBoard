using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class OrgToCharacterRelationship
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CharacterId { get; set; }
        public int RelationshipType { get; set; }
        public int? Reputation { get; set; }

        public virtual StoryCharacter Character { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual RelationshipTypeLookup RelationshipTypeNavigation { get; set; }
    }
}
