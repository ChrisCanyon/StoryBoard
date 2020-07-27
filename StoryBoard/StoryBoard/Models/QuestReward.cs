using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class QuestReward
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int QuestId { get; set; }
        public int Quantity { get; set; }

        public virtual Item Item { get; set; }
        public virtual Quest Quest { get; set; }
    }
}
