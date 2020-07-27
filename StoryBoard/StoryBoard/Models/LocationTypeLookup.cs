using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class LocationTypeLookup
    {
        public LocationTypeLookup()
        {
            StoryLocation = new HashSet<StoryLocation>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<StoryLocation> StoryLocation { get; set; }
    }
}
