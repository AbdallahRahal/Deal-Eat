create table dealeat.tUser
(
	UserId int identity(0, 1),
	[Type] nvarchar(3) collate Latin1_General_100_CI_AS not null,
	Pseudo nvarchar(45) collate Latin1_General_100_CI_AS not null,
	[Password] nvarchar(300) collate Latin1_General_100_CI_AS not null,
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	LastName nvarchar(45) collate Latin1_General_100_CI_AS not null,
	Email nvarchar(255) collate Latin1_General_100_CI_AS,
	Telephone int



	constraint PK_tUser primary key(UserId),
	constraint CK_tUser_Type check([Type] in ('merchant','admin','user'))
);
insert into dealeat.tUser([Type], Pseudo, [Password], [Name], LastName) values('user', 'UserPseudoTest', 'aaa', 'UserNameTest', 'UserLastNameTest');
