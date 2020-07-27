using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class OrganizationRank
    {
        public OrganizationRank()
        {
            OrganizationMember = new HashSet<OrganizationMember>();
        }

        public int Id { get; set; }
        public string RankDesciption { get; set; }
        public int ReputationThreshold { get; set; }

        public virtual ICollection<OrganizationMember> OrganizationMember { get; set; }
    }
}
