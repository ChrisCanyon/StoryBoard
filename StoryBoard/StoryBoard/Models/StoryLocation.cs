using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryLocation
    {
        public StoryLocation()
        {
            StoryEventLocation = new HashSet<StoryEventLocation>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public int LocationType { get; set; }

        public virtual LocationTypeLookup LocationTypeNavigation { get; set; }
        public virtual ICollection<StoryEventLocation> StoryEventLocation { get; set; }
    }
}
