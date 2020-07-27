using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryCharacter
    {
        public StoryCharacter()
        {
            CharacterToOrgRelationship = new HashSet<CharacterToOrgRelationship>();
            Inventory = new HashSet<Inventory>();
            OrgToCharacterRelationship = new HashSet<OrgToCharacterRelationship>();
            OrgToOrgRelationship = new HashSet<OrgToOrgRelationship>();
            OrganizationMember = new HashSet<OrganizationMember>();
            RelationshipFromCharacterNavigation = new HashSet<Relationship>();
            RelationshipToCharacterNavigation = new HashSet<Relationship>();
            StoryEventCharacter = new HashSet<StoryEventCharacter>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public string Gender { get; set; }
        public string Backstory { get; set; }
        public int CharacterType { get; set; }
        public string CharacterName { get; set; }
        public int CharacterLocation { get; set; }
        public int? Cr { get; set; }

        public virtual StoryLocation CharacterLocationNavigation { get; set; }
        public virtual CharacterType CharacterTypeNavigation { get; set; }
        public virtual ICollection<CharacterToOrgRelationship> CharacterToOrgRelationship { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<OrgToCharacterRelationship> OrgToCharacterRelationship { get; set; }
        public virtual ICollection<OrgToOrgRelationship> OrgToOrgRelationship { get; set; }
        public virtual ICollection<OrganizationMember> OrganizationMember { get; set; }
        public virtual ICollection<Relationship> RelationshipFromCharacterNavigation { get; set; }
        public virtual ICollection<Relationship> RelationshipToCharacterNavigation { get; set; }
        public virtual ICollection<StoryEventCharacter> StoryEventCharacter { get; set; }
    }
}
