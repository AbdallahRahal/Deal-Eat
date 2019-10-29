create proc ps.sTeacherAssignClass
(
	@TeacherId int,
	@ClassId int
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

	if not exists(select * from ps.tClass c where c.ClassId = @ClassId)
	begin
		rollback;
		return 2;
	end;

	update ps.tClass set TeacherId = 0 where TeacherId = @TeacherId;
	update ps.tClass set TeacherId = @TeacherId where ClassId = @ClassId;

	commit;
	return 0;
end;