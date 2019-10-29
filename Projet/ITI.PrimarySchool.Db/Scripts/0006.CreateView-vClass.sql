create view ps.vClass
as
	select
		ClassId = c.ClassId,
		[Name] = c.[Name],
		[Level] = c.[Level],
		TeacherId = c.TeacherId,
		TeacherFirstName = case when c.TeacherId <> 0 then t.FirstName else N'' end,
		TeacherLastName = case when c.TeacherId <> 0 then t.LastName else N'' end
	from ps.tClass c
		inner join ps.tTeacher t on t.TeacherId = c.TeacherId
	where c.ClassId <> 0;