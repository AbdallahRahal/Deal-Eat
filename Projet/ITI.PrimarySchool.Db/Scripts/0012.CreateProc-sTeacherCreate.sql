create proc ps.sTeacherCreate
(
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@TeacherId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from ps.tTeacher t where t.FirstName = @FirstName and t.LastName = @LastName)
	begin
		rollback;
		return 1;
	end;

	insert into ps.tTeacher(FirstName, LastName) values(@FirstName, @LastName);
	set @TeacherId = scope_identity();

	commit;
	return 0;
end;