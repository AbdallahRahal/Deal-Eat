create view dealeat.vHomeProfil
as
	select
		-- User
		UserId = u.UserId,
		Pseudo = u.Pseudo,
		[Name] = u.[Name],
		LastName = u.LastName
	from dealeat.tUser u