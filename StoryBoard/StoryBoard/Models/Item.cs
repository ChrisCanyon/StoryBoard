using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Item
    {
        public Item()
        {
            InventoryItem = new HashSet<InventoryItem>();
            QuestReward = new HashSet<QuestReward>();
            StoryEventItem = new HashSet<StoryEventItem>();
        }

        public int Id { get; set; }
        public string ItemDescription { get; set; }
        public byte[] Icon { get; set; }

        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
        public virtual ICollection<QuestReward> QuestReward { get; set; }
        public virtual ICollection<StoryEventItem> StoryEventItem { get; set; }
    }
}
