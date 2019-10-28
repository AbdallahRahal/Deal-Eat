create proc ps.sTeacherDelete
(
	@TeacherId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if not exists(select * from ps.tTeacher t where t.TeacherId = @TeacherId)
	begin
		rollback;
		return 1;
	end;

	update ps.tClass set TeacherId = 0 where TeacherId = @TeacherId;
	delete ps.tTeacher where TeacherId = @TeacherId;
	commit;

	return 0;
end;