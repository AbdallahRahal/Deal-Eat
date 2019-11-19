create table dealeat.tUser
(
	UserId int identity(0, 1),
	Pseudo nvarchar(45) collate Latin1_General_100_CI_AS not null,
	[Password] nvarchar(255) collate Latin1_General_100_CI_AS not null,
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	LastName nvarchar(45) collate Latin1_General_100_CI_AS not null,
	Email nvarchar(255) collate Latin1_General_100_CI_AS,
	Telephone int collate Latin1_General_100_CI_AS

	constraint PK_tUser primary key(UserId)
);