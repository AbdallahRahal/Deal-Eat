create table ps.tTeacher
(
	TeacherId int identity(0, 1),
	FirstName nvarchar(32) collate Latin1_General_100_CI_AS not null,
	LastName  nvarchar(32) collate Latin1_General_100_CI_AS not null,

	constraint PK_ps_tTeacher primary key(TeacherId),
	constraint CK_ps_tTeacher_Name check(len(FirstName) > 1 and len(LastName) > 1),
	constraint UK_ps_tTeacher unique(LastName, FirstName)
);

insert into ps.tTeacher(FirstName, LastName) values(N'N.A.', N'N.A.');