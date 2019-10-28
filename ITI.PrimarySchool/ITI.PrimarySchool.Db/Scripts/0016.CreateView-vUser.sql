create view ps.vUser
as
	select u.UserId, u.Email, u.[Password]
	from ps.tUser u
	where u.UserId <> 0;