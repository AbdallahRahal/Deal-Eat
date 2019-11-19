create table dealeat.tAdmin
(
	AdminId int identity(0, 1),

	constraint PK_tAdmin primary key(AdminId),
	constraint FK_dealeat_tAdmin_tUser foreign key(AdminId) references dealeat.tUser(UserId)
);