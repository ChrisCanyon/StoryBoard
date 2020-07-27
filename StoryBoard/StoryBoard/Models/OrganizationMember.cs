using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class OrganizationMember
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int CharacterId { get; set; }
        public int CurrentRank { get; set; }

        public virtual StoryCharacter Character { get; set; }
        public virtual OrganizationRank CurrentRankNavigation { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
