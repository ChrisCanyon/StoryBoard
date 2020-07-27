using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryEventCharacter
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CharacterId { get; set; }

        public virtual StoryCharacter Character { get; set; }
        public virtual StoryEvent Event { get; set; }
    }
}
