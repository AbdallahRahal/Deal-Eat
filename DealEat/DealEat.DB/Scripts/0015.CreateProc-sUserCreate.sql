create proc dealeat.sUserCreate
(
	@Pseudo nvarchar(45),
	@Password varbinary(255),
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

	if exists(select * from dealeat.tUser where Pseudo = @Pseudo or Email = @Email)
	begin
		rollback;
		return 1;
	end;

	insert into dealeat.tUser( Pseudo, [Password], [Name], LastName, Email, Telephone) values(@Pseudo, @Password, @Name, @LastName, @Email, @Telephone);
	set @UserId = scope_identity();

	commit;	
	return 0;
end;