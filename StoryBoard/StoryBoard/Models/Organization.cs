using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Organization
    {
        public Organization()
        {
            CharacterToOrgRelationship = new HashSet<CharacterToOrgRelationship>();
            OrgToCharacterRelationship = new HashSet<OrgToCharacterRelationship>();
            OrgToOrgRelationship = new HashSet<OrgToOrgRelationship>();
            OrganizationMember = new HashSet<OrganizationMember>();
            Quest = new HashSet<Quest>();
            StoryLocation = new HashSet<StoryLocation>();
        }

        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDescription { get; set; }
        public int Alignment { get; set; }

        public virtual AlignmentLookup AlignmentNavigation { get; set; }
        public virtual ICollection<CharacterToOrgRelationship> CharacterToOrgRelationship { get; set; }
        public virtual ICollection<OrgToCharacterRelationship> OrgToCharacterRelationship { get; set; }
        public virtual ICollection<OrgToOrgRelationship> OrgToOrgRelationship { get; set; }
        public virtual ICollection<OrganizationMember> OrganizationMember { get; set; }
        public virtual ICollection<Quest> Quest { get; set; }
        public virtual ICollection<StoryLocation> StoryLocation { get; set; }
    }
}
