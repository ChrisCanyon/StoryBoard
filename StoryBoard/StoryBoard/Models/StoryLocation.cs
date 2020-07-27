using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryLocation
    {
        public StoryLocation()
        {
            InverseContainedInNavigation = new HashSet<StoryLocation>();
            Quest = new HashSet<Quest>();
            StoryCharacter = new HashSet<StoryCharacter>();
            StoryEventLocation = new HashSet<StoryEventLocation>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public int LocationType { get; set; }
        public double CoordinatesX { get; set; }
        public double CoordinatesY { get; set; }
        public int? ContainedIn { get; set; }
        public int? AssociatedOrganization { get; set; }

        public virtual Organization AssociatedOrganizationNavigation { get; set; }
        public virtual StoryLocation ContainedInNavigation { get; set; }
        public virtual LocationTypeLookup LocationTypeNavigation { get; set; }
        public virtual ICollection<StoryLocation> InverseContainedInNavigation { get; set; }
        public virtual ICollection<Quest> Quest { get; set; }
        public virtual ICollection<StoryCharacter> StoryCharacter { get; set; }
        public virtual ICollection<StoryEventLocation> StoryEventLocation { get; set; }
    }
}
