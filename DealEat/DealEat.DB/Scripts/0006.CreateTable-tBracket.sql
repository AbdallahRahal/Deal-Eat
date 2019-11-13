create table dealeat.tBracket
(
	BracketId int identity(0, 1),
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	PhotoLink nvarchar(255) collate Latin1_General_100_CI_AS not null,
	Price int,
	Information text collate Latin1_General_100_CI_AS

	constraint PK_dealeat_tBracket primary key(BracketId),
);