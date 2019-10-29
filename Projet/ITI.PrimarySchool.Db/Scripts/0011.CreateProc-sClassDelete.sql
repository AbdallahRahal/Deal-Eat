create proc ps.sClassDelete
(
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

	update ps.tStudent set ClassId = 0 where ClassId = @ClassId;
	delete ps.tClass where ClassId = @ClassId;
	commit;

	return 0;
end;