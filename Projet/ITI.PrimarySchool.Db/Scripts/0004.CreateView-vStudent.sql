create view ps.vStudent
as
	select
		StudentId = s.StudentId,
		FirstName = s.FirstName,
		LastName = s.LastName,
		BirthDate = s.BirthDate,
		ClassId = c.ClassId,
		ClassName = case when c.ClassId <> 0 then c.[Name] else N'' end,
		[Level] = case when c.ClassId <> 0 then c.[Level] else '' end,
		TeacherId = t.TeacherId,
		TeacherFirstName = case when t.TeacherId <> 0 then t.FirstName else N'' end,
		TeacherLastName = case when t.TeacherId <> 0 then t.LastName else N'' end
	from ps.tStudent s
		inner join ps.tClass c on c.ClassId = s.ClassId
		inner join ps.tTeacher t on t.TeacherId = c.TeacherId
	where s.StudentId <> 0;