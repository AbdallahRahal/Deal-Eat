create proc ps.sStudentAssignClass
(
	@StudentId int,
	@ClassId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;
	if not exists(select * from ps.tClass c where c.ClassId = @ClassId)
	begin
		rollback;
		return 1;
	end;

	if not exists(select * from ps.tStudent s where s.StudentId = @StudentId)
	begin
		rollback;
		return 2;
	end;

	update ps.tStudent set ClassId = @ClassId where StudentId = @StudentId;

	commit;
	return 0;
end;