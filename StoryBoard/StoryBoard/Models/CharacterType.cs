using System;
using System.Collections.Generic;

namespace StoryBoard.Models
{
    public partial class CharacterType
    {
        public CharacterType()
        {
            StoryCharacter = new HashSet<StoryCharacter>();
        }

        public int Id { get; set; }
        public string DisplayText { get; set; }
        public bool? IsNpc { get; set; }

        public virtual ICollection<StoryCharacter> StoryCharacter { get; set; }
    }
}
