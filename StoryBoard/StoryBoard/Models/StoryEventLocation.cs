using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryEventLocation
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int LocationId { get; set; }

        public virtual StoryEvent Event { get; set; }
        public virtual StoryLocation Location { get; set; }
    }
}
