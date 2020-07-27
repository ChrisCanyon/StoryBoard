using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class AlignmentLookup
    {
        public AlignmentLookup()
        {
            Organization = new HashSet<Organization>();
        }

        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string ShortText { get; set; }

        public virtual ICollection<Organization> Organization { get; set; }
    }
}
