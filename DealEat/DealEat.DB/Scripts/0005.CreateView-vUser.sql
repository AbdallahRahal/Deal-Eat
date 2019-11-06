create view dealeat.vUser
as
	select
		UserId = u.UserId,
		[Type] = u.[Type],
		Email = u.Email,
		[Name] = u.[Name],
		LastName = u.LastName,
		Pseudo = u.Pseudo,
		[Password] = u.[Password]
	from dealeat.uUser u
	where u.UserId <> 0;