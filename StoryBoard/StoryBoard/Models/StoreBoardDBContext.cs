using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoryBoard.Models
{
    public partial class StoreBoardDBContext : DbContext
    {
        public StoreBoardDBContext()
        {
        }

        public StoreBoardDBContext(DbContextOptions<StoreBoardDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CharacterType> CharacterType { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<LocationTypeLookup> LocationTypeLookup { get; set; }
        public virtual DbSet<Quest> Quest { get; set; }
        public virtual DbSet<QuestEvent> QuestEvent { get; set; }
        public virtual DbSet<QuestReward> QuestReward { get; set; }
        public virtual DbSet<Relationship> Relationship { get; set; }
        public virtual DbSet<RelationshipTypeLookup> RelationshipTypeLookup { get; set; }
        public virtual DbSet<StoryCharacter> StoryCharacter { get; set; }
        public virtual DbSet<StoryEvent> StoryEvent { get; set; }
        public virtual DbSet<StoryEventCharacter> StoryEventCharacter { get; set; }
        public virtual DbSet<StoryEventItem> StoryEventItem { get; set; }
        public virtual DbSet<StoryEventLocation> StoryEventLocation { get; set; }
        public virtual DbSet<StoryLocation> StoryLocation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:storyboard-db-server.database.windows.net,1433;Initial Catalog=StoreBoardDB;Persist Security Info=False;User ID=storyboardadmin;Password=appleSAUCE117)(;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterType>(entity =>
            {
                entity.ToTable("character_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayText)
                    .HasColumnName("displayText")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IsNpc).HasColumnName("isNPC");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__chara__245D67DE");
            });

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.ToTable("inventory_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InventoryId).HasColumnName("inventoryId");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.InventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__inven__2739D489");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__itemI__282DF8C2");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("itemDescription")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<LocationTypeLookup>(entity =>
            {
                entity.ToTable("location_type_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.TypeDescription)
                    .HasColumnName("typeDescription")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quest>(entity =>
            {
                entity.ToTable("quest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Hook)
                    .HasColumnName("hook")
                    .HasMaxLength(280)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.QuestDescription)
                    .HasColumnName("questDescription")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestEvent>(entity =>
            {
                entity.ToTable("quest_event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.QuestId).HasColumnName("questId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.QuestEvent)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_eve__event__30C33EC3");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestEvent)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_eve__quest__2FCF1A8A");
            });

            modelBuilder.Entity<QuestReward>(entity =>
            {
                entity.ToTable("quest_reward");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.QuestId).HasColumnName("questId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.QuestReward)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_rew__itemI__339FAB6E");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestReward)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_rew__quest__3493CFA7");
            });

            modelBuilder.Entity<Relationship>(entity =>
            {
                entity.ToTable("relationship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FromCharacter).HasColumnName("fromCharacter");

                entity.Property(e => e.RelationshipType).HasColumnName("relationshipType");

                entity.Property(e => e.Reputation)
                    .HasColumnName("reputation")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ToCharacter).HasColumnName("toCharacter");

                entity.HasOne(d => d.FromCharacterNavigation)
                    .WithMany(p => p.RelationshipFromCharacterNavigation)
                    .HasForeignKey(d => d.FromCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relations__fromC__0A9D95DB");

                entity.HasOne(d => d.RelationshipTypeNavigation)
                    .WithMany(p => p.Relationship)
                    .HasForeignKey(d => d.RelationshipType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relations__relat__08B54D69");

                entity.HasOne(d => d.ToCharacterNavigation)
                    .WithMany(p => p.RelationshipToCharacterNavigation)
                    .HasForeignKey(d => d.ToCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relations__toCha__0B91BA14");
            });

            modelBuilder.Entity<RelationshipTypeLookup>(entity =>
            {
                entity.ToTable("relationship_type_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RelationshipDesciption)
                    .HasColumnName("relationshipDesciption")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReputationThreshold).HasColumnName("reputationThreshold");
            });

            modelBuilder.Entity<StoryCharacter>(entity =>
            {
                entity.ToTable("story_character");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Backstory)
                    .HasColumnName("backstory")
                    .IsUnicode(false);

                entity.Property(e => e.CharacterType).HasColumnName("characterType");

                entity.Property(e => e.Cr)
                    .HasColumnName("CR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.HasOne(d => d.CharacterTypeNavigation)
                    .WithMany(p => p.StoryCharacter)
                    .HasForeignKey(d => d.CharacterType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_cha__chara__02FC7413");
            });

            modelBuilder.Entity<StoryEvent>(entity =>
            {
                entity.ToTable("story_event");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompletedDate)
                    .HasColumnName("completedDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .HasColumnName("eventDescription")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.IsCompleted).HasColumnName("isCompleted");
            });

            modelBuilder.Entity<StoryEventCharacter>(entity =>
            {
                entity.ToTable("story_event_character");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.StoryEventCharacter)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__chara__2180FB33");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StoryEventCharacter)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__event__208CD6FA");
            });

            modelBuilder.Entity<StoryEventItem>(entity =>
            {
                entity.ToTable("story_event_item");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StoryEventItem)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__event__18EBB532");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StoryEventItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__itemI__19DFD96B");
            });

            modelBuilder.Entity<StoryEventLocation>(entity =>
            {
                entity.ToTable("story_event_location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventId).HasColumnName("eventId");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StoryEventLocation)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__event__1CBC4616");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoryEventLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__locat__1DB06A4F");
            });

            modelBuilder.Entity<StoryLocation>(entity =>
            {
                entity.ToTable("story_location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.LocationType).HasColumnName("locationType");

                entity.HasOne(d => d.LocationTypeNavigation)
                    .WithMany(p => p.StoryLocation)
                    .HasForeignKey(d => d.LocationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_loc__locat__10566F31");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
