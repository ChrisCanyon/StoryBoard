create table character_type (
	id INT IDENTITY(1,1) PRIMARY KEY,
	displayText varchar(255),
	isNPC bit
);

create table alignment_lookup (
	id INT IDENTITY(1,1) PRIMARY KEY,
	displayText varchar(255),
	shortText varchar(2)
);

INSERT INTO alignment_lookup
VALUES ('Lawful Good', 'LG'), ('Neurtal Good', 'NG'), ('Chaotic Good', 'CG'),
	('Lawful Neutral', 'LN'), ('True Neutral', 'N'), ('Chaotic Neutral', 'CN'),
	('Lawful Evil', 'LE'), ('Neurtal Evil', 'NE'), ('Chaotic Evil', 'CE');

create table organization (
	id INT IDENTITY(1,1) PRIMARY KEY,
	organizationName varchar(255),
	organizationDescription varchar(MAX),
	alignment INT FOREIGN KEY REFERENCES alignment_lookup(id) NOT NULL,
);

create table location_type_lookup (
	id INT IDENTITY(1,1) PRIMARY KEY,
	icon VARBINARY(MAX),
	typeDescription varchar(255)
);

create table story_location (
	id INT IDENTITY(1,1) PRIMARY KEY,
	icon VARBINARY(MAX),
	locationType INT FOREIGN KEY REFERENCES location_type_lookup(id) NOT NULL,
	coordinatesX float not null,
	coordinatesY float not null,
	containedIn INT FOREIGN KEY REFERENCES story_location(id),
	associatedOrganization INT FOREIGN KEY REFERENCES organization(id)
);

create table story_character (
	id INT IDENTITY(1,1) PRIMARY KEY,
	icon VARBINARY(MAX),
	gender varchar(255),
	backstory varchar(MAX),
	characterType INT FOREIGN KEY REFERENCES character_type(id) NOT NULL,
	characterName varchar(255) not null,
	characterLocation INT FOREIGN KEY REFERENCES story_location(id) NOT NULL, 
	CR INT default 0
);

create table relationship_type_lookup (
	id INT IDENTITY(1,1) PRIMARY KEY,
	relationshipDesciption varchar(255),
	reputationThreshold INT NOT NULL,
);

create table relationship (
	id INT IDENTITY(1,1) PRIMARY KEY,
	relationshipType INT FOREIGN KEY REFERENCES relationship_type_lookup(id) NOT NULL,
	reputation INT default 0,
	fromCharacter INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
	toCharacter INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
);

create table item (
	id INT IDENTITY(1,1) PRIMARY KEY,
	itemDescription varchar(MAX) default '',
	icon VARBINARY(MAX)
);

create table story_event (
	id INT IDENTITY(1,1) PRIMARY KEY,
	eventDescription varchar(MAX) default '',
	isCompleted bit,
	completedDate DATETIME,
	precedence INT default 0
);

create table story_event_item (
	id INT IDENTITY(1,1) PRIMARY KEY,
	eventId INT FOREIGN KEY REFERENCES story_event(id) NOT NULL,
	itemId INT FOREIGN KEY REFERENCES item(id) NOT NULL,
);

create table story_event_location (
	id INT IDENTITY(1,1) PRIMARY KEY,
	eventId INT FOREIGN KEY REFERENCES story_event(id) NOT NULL,
	locationId INT FOREIGN KEY REFERENCES story_location(id) NOT NULL,
);

create table story_event_character (
	id INT IDENTITY(1,1) PRIMARY KEY,
	eventId INT FOREIGN KEY REFERENCES story_event(id) NOT NULL,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
); 

create table inventory (
	id INT IDENTITY(1,1) PRIMARY KEY,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
);

create table inventory_item (
	id INT IDENTITY(1,1) PRIMARY KEY,
	inventoryId INT FOREIGN KEY REFERENCES inventory(id) NOT NULL,
	itemId INT FOREIGN KEY REFERENCES item(id) NOT NULL,
	quantity INT default 1
);

create table quest (
	id INT IDENTITY(1,1) PRIMARY KEY,
	questDescription varchar(MAX) DEFAULT '',
	hook varchar(280) default '' /*If you cant make it sound good as a tweet, I dont want to do your quest*/,
	title varchar(255) not null,
	startLocation INT FOREIGN KEY REFERENCES story_location(id) NOT NULL,
	organization INT FOREIGN KEY REFERENCES organization(id),
	prequelId INT FOREIGN KEY REFERENCES quest(id),
	CR int not null
); 

create table quest_event (
	id INT IDENTITY(1,1) PRIMARY KEY,
	questId INT FOREIGN KEY REFERENCES quest(id) NOT NULL,
	eventId INT FOREIGN KEY REFERENCES story_event(id) NOT NULL,
); 

create table quest_reward (
	id INT IDENTITY(1,1) PRIMARY KEY,
	itemId INT FOREIGN KEY REFERENCES item(id) NOT NULL,
	questId INT FOREIGN KEY REFERENCES quest(id) NOT NULL,
	quantity INT DEFAULT 1 NOT NULL
); 

create table organization_rank(
	id INT IDENTITY(1,1) PRIMARY KEY,
	rankDesciption varchar(255),
	reputationThreshold INT NOT NULL
);

create table organization_member (
	id INT IDENTITY(1,1) PRIMARY KEY,
	organizationId INT FOREIGN KEY REFERENCES organization(id) NOT NULL,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
	currentRank INT FOREIGN KEY REFERENCES organization_rank(id) NOT NULL
);

create table character_to_org_relationship (
	id INT IDENTITY(1,1) PRIMARY KEY,
	organizationId INT FOREIGN KEY REFERENCES organization(id) NOT NULL,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
	relationshipType INT FOREIGN KEY REFERENCES relationship_type_lookup(id) NOT NULL,
	reputation INT default 0,
)

create table org_to_character_relationship (
	id INT IDENTITY(1,1) PRIMARY KEY,
	organizationId INT FOREIGN KEY REFERENCES organization(id) NOT NULL,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
	relationshipType INT FOREIGN KEY REFERENCES relationship_type_lookup(id) NOT NULL,
	reputation INT default 0,
)

create table org_to_org_relationship (
	id INT IDENTITY(1,1) PRIMARY KEY,
	organizationId INT FOREIGN KEY REFERENCES organization(id) NOT NULL,
	characterId INT FOREIGN KEY REFERENCES story_character(id) NOT NULL,
	relationshipType INT FOREIGN KEY REFERENCES relationship_type_lookup(id) NOT NULL,
	reputation INT default 0,
)