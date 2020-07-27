using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Quest
    {
        public Quest()
        {
            InversePrequel = new HashSet<Quest>();
            QuestEvent = new HashSet<QuestEvent>();
            QuestReward = new HashSet<QuestReward>();
        }

        public int Id { get; set; }
        public string QuestDescription { get; set; }
        public string Hook { get; set; }
        public string Title { get; set; }
        public int StartLocation { get; set; }
        public int? Organization { get; set; }
        public int? PrequelId { get; set; }
        public int Cr { get; set; }

        public virtual Organization OrganizationNavigation { get; set; }
        public virtual Quest Prequel { get; set; }
        public virtual StoryLocation StartLocationNavigation { get; set; }
        public virtual ICollection<Quest> InversePrequel { get; set; }
        public virtual ICollection<QuestEvent> QuestEvent { get; set; }
        public virtual ICollection<QuestReward> QuestReward { get; set; }
    }
}
