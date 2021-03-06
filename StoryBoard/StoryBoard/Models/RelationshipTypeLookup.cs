﻿using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class RelationshipTypeLookup
    {
        public RelationshipTypeLookup()
        {
            CharacterToOrgRelationship = new HashSet<CharacterToOrgRelationship>();
            OrgToCharacterRelationship = new HashSet<OrgToCharacterRelationship>();
            OrgToOrgRelationship = new HashSet<OrgToOrgRelationship>();
            Relationship = new HashSet<Relationship>();
        }

        public int Id { get; set; }
        public string RelationshipDesciption { get; set; }
        public int ReputationThreshold { get; set; }

        public virtual ICollection<CharacterToOrgRelationship> CharacterToOrgRelationship { get; set; }
        public virtual ICollection<OrgToCharacterRelationship> OrgToCharacterRelationship { get; set; }
        public virtual ICollection<OrgToOrgRelationship> OrgToOrgRelationship { get; set; }
        public virtual ICollection<Relationship> Relationship { get; set; }
    }
}
