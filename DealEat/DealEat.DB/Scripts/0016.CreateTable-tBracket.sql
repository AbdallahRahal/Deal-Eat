create table dealeat.tBracket
(
	BracketId int identity(0, 1),
	[Type] nvarchar(45) collate Latin1_General_100_CI_AS not null,

	constraint PK_dealeat_tBracket primary key(BracketId)
);
