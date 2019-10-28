create table ps.tClass
(
	ClassId    int identity(0, 1),
	[Name]     nvarchar(8) collate Latin1_General_100_CI_AS not null,
	[Level]    varchar(3) collate Latin1_General_100_CI_AS not null,
	TeacherId  int not null,

	constraint PK_ps_tClass primary key(ClassId),
	constraint FK_ps_tClass foreign key(TeacherId) references ps.tTeacher(TeacherId),
	constraint CK_ps_tClass_Level check([Level] in ('CP', 'CE1', 'CE2', 'CM1', 'CM2')),
	constraint UK_ps_tClass_Name unique([Name])
);

create unique index IX_ps_tClass_TeacherId on ps.tClass(TeacherId) where TeacherId > 0;

insert into ps.tClass([Name], [Level], TeacherId) values(N'', 'CP', 0);