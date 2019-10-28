create table ps.tStudent
(
	StudentId int identity(0, 1),
	FirstName nvarchar(32) collate Latin1_General_100_CI_AS not null,
	LastName  nvarchar(32) collate Latin1_General_100_CI_AS not null,
	BirthDate datetime2 not null,
	ClassId   int not null,

	constraint PK_ps_tStudent primary key(StudentId),
	constraint FK_ps_tStudent_ClassId foreign key(ClassId) references ps.tClass(ClassId),
	constraint UK_ps_tStudent_Name unique(LastName, FirstName)
);

insert into ps.tStudent(FirstName, LastName, BirthDate, ClassId) values(N'', N'', '00010101', 0);