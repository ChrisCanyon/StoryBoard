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

        public virtual DbSet<AlignmentLookup> AlignmentLookup { get; set; }
        public virtual DbSet<CharacterToOrgRelationship> CharacterToOrgRelationship { get; set; }
        public virtual DbSet<CharacterType> CharacterType { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<LocationTypeLookup> LocationTypeLookup { get; set; }
        public virtual DbSet<OrgToCharacterRelationship> OrgToCharacterRelationship { get; set; }
        public virtual DbSet<OrgToOrgRelationship> OrgToOrgRelationship { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<OrganizationMember> OrganizationMember { get; set; }
        public virtual DbSet<OrganizationRank> OrganizationRank { get; set; }
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
            modelBuilder.Entity<AlignmentLookup>(entity =>
            {
                entity.ToTable("alignment_lookup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DisplayText)
                    .HasColumnName("displayText")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortText)
                    .HasColumnName("shortText")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CharacterToOrgRelationship>(entity =>
            {
                entity.ToTable("character_to_org_relationship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.Property(e => e.OrganizationId).HasColumnName("organizationId");

                entity.Property(e => e.RelationshipType).HasColumnName("relationshipType");

                entity.Property(e => e.Reputation)
                    .HasColumnName("reputation")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterToOrgRelationship)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__character__chara__75F77EB0");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.CharacterToOrgRelationship)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__character__organ__75035A77");

                entity.HasOne(d => d.RelationshipTypeNavigation)
                    .WithMany(p => p.CharacterToOrgRelationship)
                    .HasForeignKey(d => d.RelationshipType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__character__relat__76EBA2E9");
            });

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
                    .HasConstraintName("FK__inventory__chara__5772F790");
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
                    .HasConstraintName("FK__inventory__inven__5A4F643B");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__inventory__itemI__5B438874");
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

            modelBuilder.Entity<OrgToCharacterRelationship>(entity =>
            {
                entity.ToTable("org_to_character_relationship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.Property(e => e.OrganizationId).HasColumnName("organizationId");

                entity.Property(e => e.RelationshipType).HasColumnName("relationshipType");

                entity.Property(e => e.Reputation)
                    .HasColumnName("reputation")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.OrgToCharacterRelationship)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_ch__chara__7BB05806");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrgToCharacterRelationship)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_ch__organ__7ABC33CD");

                entity.HasOne(d => d.RelationshipTypeNavigation)
                    .WithMany(p => p.OrgToCharacterRelationship)
                    .HasForeignKey(d => d.RelationshipType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_ch__relat__7CA47C3F");
            });

            modelBuilder.Entity<OrgToOrgRelationship>(entity =>
            {
                entity.ToTable("org_to_org_relationship");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.Property(e => e.OrganizationId).HasColumnName("organizationId");

                entity.Property(e => e.RelationshipType).HasColumnName("relationshipType");

                entity.Property(e => e.Reputation)
                    .HasColumnName("reputation")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.OrgToOrgRelationship)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_or__chara__0169315C");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrgToOrgRelationship)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_or__organ__00750D23");

                entity.HasOne(d => d.RelationshipTypeNavigation)
                    .WithMany(p => p.OrgToOrgRelationship)
                    .HasForeignKey(d => d.RelationshipType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__org_to_or__relat__025D5595");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("organization");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alignment).HasColumnName("alignment");

                entity.Property(e => e.OrganizationDescription)
                    .HasColumnName("organizationDescription")
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .HasColumnName("organizationName")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.AlignmentNavigation)
                    .WithMany(p => p.Organization)
                    .HasForeignKey(d => d.Alignment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__organizat__align__2F650636");
            });

            modelBuilder.Entity<OrganizationMember>(entity =>
            {
                entity.ToTable("organization_member");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CharacterId).HasColumnName("characterId");

                entity.Property(e => e.CurrentRank).HasColumnName("currentRank");

                entity.Property(e => e.OrganizationId).HasColumnName("organizationId");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.OrganizationMember)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__organizat__chara__7132C993");

                entity.HasOne(d => d.CurrentRankNavigation)
                    .WithMany(p => p.OrganizationMember)
                    .HasForeignKey(d => d.CurrentRank)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__organizat__curre__7226EDCC");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationMember)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__organizat__organ__703EA55A");
            });

            modelBuilder.Entity<OrganizationRank>(entity =>
            {
                entity.ToTable("organization_rank");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RankDesciption)
                    .HasColumnName("rankDesciption")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReputationThreshold).HasColumnName("reputationThreshold");
            });

            modelBuilder.Entity<Quest>(entity =>
            {
                entity.ToTable("quest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cr).HasColumnName("CR");

                entity.Property(e => e.Hook)
                    .HasColumnName("hook")
                    .HasMaxLength(280)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Organization).HasColumnName("organization");

                entity.Property(e => e.PrequelId).HasColumnName("prequelId");

                entity.Property(e => e.QuestDescription)
                    .HasColumnName("questDescription")
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StartLocation).HasColumnName("startLocation");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.OrganizationNavigation)
                    .WithMany(p => p.Quest)
                    .HasForeignKey(d => d.Organization)
                    .HasConstraintName("FK__quest__organizat__61F08603");

                entity.HasOne(d => d.Prequel)
                    .WithMany(p => p.InversePrequel)
                    .HasForeignKey(d => d.PrequelId)
                    .HasConstraintName("FK__quest__prequelId__62E4AA3C");

                entity.HasOne(d => d.StartLocationNavigation)
                    .WithMany(p => p.Quest)
                    .HasForeignKey(d => d.StartLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest__startLoca__60FC61CA");
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
                    .HasConstraintName("FK__quest_eve__event__66B53B20");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestEvent)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_eve__quest__65C116E7");
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
                    .HasConstraintName("FK__quest_rew__itemI__6991A7CB");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestReward)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quest_rew__quest__6A85CC04");
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
                    .HasConstraintName("FK__relations__fromC__4183B671");

                entity.HasOne(d => d.RelationshipTypeNavigation)
                    .WithMany(p => p.Relationship)
                    .HasForeignKey(d => d.RelationshipType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relations__relat__3F9B6DFF");

                entity.HasOne(d => d.ToCharacterNavigation)
                    .WithMany(p => p.RelationshipToCharacterNavigation)
                    .HasForeignKey(d => d.ToCharacter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__relations__toCha__4277DAAA");
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

                entity.Property(e => e.CharacterLocation).HasColumnName("characterLocation");

                entity.Property(e => e.CharacterName)
                    .IsRequired()
                    .HasColumnName("characterName")
                    .HasMaxLength(255)
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

                entity.HasOne(d => d.CharacterLocationNavigation)
                    .WithMany(p => p.StoryCharacter)
                    .HasForeignKey(d => d.CharacterLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_cha__chara__39E294A9");

                entity.HasOne(d => d.CharacterTypeNavigation)
                    .WithMany(p => p.StoryCharacter)
                    .HasForeignKey(d => d.CharacterType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_cha__chara__38EE7070");
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

                entity.Property(e => e.Precedence)
                    .HasColumnName("precedence")
                    .HasDefaultValueSql("((0))");
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
                    .HasConstraintName("FK__story_eve__chara__54968AE5");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.StoryEventCharacter)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__event__53A266AC");
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
                    .HasConstraintName("FK__story_eve__event__4C0144E4");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StoryEventItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__itemI__4CF5691D");
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
                    .HasConstraintName("FK__story_eve__event__4FD1D5C8");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.StoryEventLocation)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_eve__locat__50C5FA01");
            });

            modelBuilder.Entity<StoryLocation>(entity =>
            {
                entity.ToTable("story_location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AssociatedOrganization).HasColumnName("associatedOrganization");

                entity.Property(e => e.ContainedIn).HasColumnName("containedIn");

                entity.Property(e => e.CoordinatesX).HasColumnName("coordinatesX");

                entity.Property(e => e.CoordinatesY).HasColumnName("coordinatesY");

                entity.Property(e => e.Icon).HasColumnName("icon");

                entity.Property(e => e.LocationType).HasColumnName("locationType");

                entity.HasOne(d => d.AssociatedOrganizationNavigation)
                    .WithMany(p => p.StoryLocation)
                    .HasForeignKey(d => d.AssociatedOrganization)
                    .HasConstraintName("FK__story_loc__assoc__361203C5");

                entity.HasOne(d => d.ContainedInNavigation)
                    .WithMany(p => p.InverseContainedInNavigation)
                    .HasForeignKey(d => d.ContainedIn)
                    .HasConstraintName("FK__story_loc__conta__351DDF8C");

                entity.HasOne(d => d.LocationTypeNavigation)
                    .WithMany(p => p.StoryLocation)
                    .HasForeignKey(d => d.LocationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__story_loc__locat__3429BB53");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
