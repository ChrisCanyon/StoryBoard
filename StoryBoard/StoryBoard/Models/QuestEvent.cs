using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class QuestEvent
    {
        public int Id { get; set; }
        public int QuestId { get; set; }
        public int EventId { get; set; }

        public virtual StoryEvent Event { get; set; }
        public virtual Quest Quest { get; set; }
    }
}
