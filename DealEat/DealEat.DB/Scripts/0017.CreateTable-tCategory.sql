create table dealeat.tCategory
(
	CategoryId int identity(0, 1),
	Category nvarchar(45) collate Latin1_General_100_CI_AS not null,

	constraint PK_dealeat_tCategory primary key(CategoryId)
);
