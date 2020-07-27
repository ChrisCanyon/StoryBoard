using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryEvent
    {
        public StoryEvent()
        {
            QuestEvent = new HashSet<QuestEvent>();
            StoryEventCharacter = new HashSet<StoryEventCharacter>();
            StoryEventItem = new HashSet<StoryEventItem>();
            StoryEventLocation = new HashSet<StoryEventLocation>();
        }

        public int Id { get; set; }
        public string EventDescription { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? Precedence { get; set; }

        public virtual ICollection<QuestEvent> QuestEvent { get; set; }
        public virtual ICollection<StoryEventCharacter> StoryEventCharacter { get; set; }
        public virtual ICollection<StoryEventItem> StoryEventItem { get; set; }
        public virtual ICollection<StoryEventLocation> StoryEventLocation { get; set; }
    }
}
