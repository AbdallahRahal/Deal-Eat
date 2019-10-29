create table ps.tUser
(
	UserId int identity(0, 1),
	Email varchar(64) collate Latin1_General_100_CI_AS not null,
	[Password] varbinary(128) not null,

	constraint PK_ps_tUser primary key(UserId),
	constraint UK_ps_tUser_Email unique(Email)
);

insert into ps.tUser(Email, [Password]) values('', 0x);
