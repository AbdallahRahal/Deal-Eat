create view ps.vTeacher
as
	select
		TeacherId = t.TeacherId,
		FirstName = t.FirstName,
		LastName = t.LastName,
		ClassId = coalesce(c.ClassId, 0),
		ClassName = coalesce(c.[Name], N''),
		ClassLevel = coalesce(c.[Level], '')
	from ps.tTeacher t
		left outer join ps.tClass c on c.TeacherId = t.TeacherId
	where t.TeacherId <> 0;