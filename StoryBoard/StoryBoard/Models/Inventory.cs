using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryItem = new HashSet<InventoryItem>();
        }

        public int Id { get; set; }
        public int CharacterId { get; set; }

        public virtual StoryCharacter Character { get; set; }
        public virtual ICollection<InventoryItem> InventoryItem { get; set; }
    }
}
