using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class InventoryItem
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public int? Quantity { get; set; }

        public virtual Inventory Inventory { get; set; }
        public virtual Item Item { get; set; }
    }
}
