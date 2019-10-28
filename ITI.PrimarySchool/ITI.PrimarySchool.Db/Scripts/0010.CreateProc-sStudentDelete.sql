create proc ps.sStudentDelete
(
	@StudentId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if not exists(select * from ps.tStudent s where s.StudentId = @StudentId)
	begin
		rollback;
		return 1;
	end;

	delete from ps.tStudent where StudentId = @StudentId;

	commit;
	return 0;
end;