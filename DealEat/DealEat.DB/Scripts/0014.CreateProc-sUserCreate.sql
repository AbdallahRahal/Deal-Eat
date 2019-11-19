create proc dealeat.sUserCreate
(
	@Pseudo nvarchar(45),
	@Password nvarchar(45),
	@Name nvarchar(45),
	@LastName nvarchar(45),
	@Email nvarchar(255),
	@Telephone int,
	@UserId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from dealeat.tUser u where u.Pseudo = @Pseudo and u.[Password] = @Password and u.[Name] = @Name and u.LastName = @LastName and u.Email = @Email and u.Telephone = @Telephone)
	begin
		rollback;
		return 1;
	end;

	insert into dealeat.tUser( Pseudo, [Password], [Name], LastName, Email, Telephone) values(@Pseudo, @Password, @Name, @LastName, @Email, @Telephone);
	set @UserId = scope_identity();

	commit;
	return 0;
end;