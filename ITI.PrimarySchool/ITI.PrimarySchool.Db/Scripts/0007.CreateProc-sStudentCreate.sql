create proc ps.sStudentCreate
(
	@FirstName nvarchar(32),
	@LastName nvarchar(32),
	@BirthDate datetime2,
	@StudentId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from ps.tStudent s where s.FirstName = @FirstName and s.LastName = @LastName)
	begin
		rollback;
		return 1;
	end;

	insert into ps.tStudent(FirstName,  LastName,  BirthDate,  ClassId)
	                 values(@FirstName, @LastName, @BirthDate, 0);

	set @StudentId = scope_identity();
	commit;
	return 0;
end;