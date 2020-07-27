using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class StoryCharacter
    {
        public StoryCharacter()
        {
            Inventory = new HashSet<Inventory>();
            RelationshipFromCharacterNavigation = new HashSet<Relationship>();
            RelationshipToCharacterNavigation = new HashSet<Relationship>();
            StoryEventCharacter = new HashSet<StoryEventCharacter>();
        }

        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public string Gender { get; set; }
        public string Backstory { get; set; }
        public int CharacterType { get; set; }
        public int? Cr { get; set; }

        public virtual CharacterType CharacterTypeNavigation { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Relationship> RelationshipFromCharacterNavigation { get; set; }
        public virtual ICollection<Relationship> RelationshipToCharacterNavigation { get; set; }
        public virtual ICollection<StoryEventCharacter> StoryEventCharacter { get; set; }
    }
}
