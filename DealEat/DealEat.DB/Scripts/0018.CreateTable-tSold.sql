create table dealeat.tSold
(
	SoldId int identity(0, 1),
	Reduction int collate Latin1_General_100_CI_AS not null,
	[Start_Date] DATE,
	[End_Date] DATE,
	BracketId int not null,

	constraint PK_dealeat_tSold primary key(SoldId),
	constraint FK_dealeat_tSold_tBracket foreign key(BracketId) references dealeat.tSold(BracketId) 
);
