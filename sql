use simone
go

create table [User]
(
  userId int identity(1,1) primary key,
  [login] nvarchar(50) not null unique,
  [password] nvarchar(50) not null,
  Email nvarchar(100) not null,
  Delted bit Null,
)

create table SearchProfile
(
   searchProfileId int identity(1,1) primary key,
   sex bit,
   [userId] int foreign key references [User](userId)
)

create table UserProfile
(
   userProfileId int identity(1,1) primary key,
   sex char NOT NULL,
   fullname Nvarchar(50) NOT NULL,
   alder int NOT NULL,
   [by] Nvarchar(50) NOT NULL,
   hvemerjeg Nvarchar(100) NOT NULL,
   jegsoger Nvarchar(50) NOT NULL, 
   interesser Nvarchar(50) NOT NULL,
   [userId] int foreign key references [User](userId)
)

create table Interests
(
  interestsID int identity(1,1) primary key,
  longDesc nvarchar(100) not null
)

create table [Message]
(
  messageId int identity(1,1),
  senderId int foreign key references UserProfile(userProfileId) not null,
  [receiver] int foreign key references UserProfile(userProfileId) not null,
  MessageText nvarchar(2000),
  isRead bit,
)

Alter table [Message]
Add constraint PK_Message primary key (messageId, senderId, [receiver])

create table [Match]
(
  messageId int identity(1,1) primary key,
  senderId int foreign key references UserProfile(userProfileId),
  [receiver] int foreign key references UserProfile(userProfileId),
  isMatch bit,
)

create table [ProfileInterests]
(
	userProfileId int foreign key references UserProfile(userProfileId) not null,
	interestsId int foreign key references Interests(interestsID) not null
)

Alter Table ProfileInterests
Add constraint PK_ProfileInterests primary key (userProfileId, interestsId);


