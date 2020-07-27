using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryEventItem
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ItemId { get; set; }

        public virtual StoryEvent Event { get; set; }
        public virtual Item Item { get; set; }
    }
}
