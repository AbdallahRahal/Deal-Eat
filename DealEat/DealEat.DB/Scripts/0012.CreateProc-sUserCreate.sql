create proc dealeat.sUserCreate
(
	@Type ENUM('merchant', 'admin', 'user'),
	@Email nvarchar(255),
	@Name nvarchar(45),
	@LastName nvarchar(45),
	@Pseudo nvarchar(45),
	@Password nvarchar(45),
	@UserId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from dealeat.tUser u where u.[Name] = @Name and u.LastName = @LastName and u.Email = @Email)
	begin
		rollback;
		return 1;
	end;

	insert into dealeat.tUser(Email, [Name], LastName) values(Email, @Name, @LastName);
	set @UserId = scope_identity();

	commit;
	return 0;
end;