using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Quest
    {
        public Quest()
        {
            QuestEvent = new HashSet<QuestEvent>();
            QuestReward = new HashSet<QuestReward>();
        }

        public int Id { get; set; }
        public string QuestDescription { get; set; }
        public string Hook { get; set; }
        public string Title { get; set; }

        public virtual ICollection<QuestEvent> QuestEvent { get; set; }
        public virtual ICollection<QuestReward> QuestReward { get; set; }
    }
}
