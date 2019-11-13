create proc dealeat.sCategoryDelete
(
	@CategoryId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	delete from dealeat.tCategory where CategoryId = @CategoryId;

	commit;
	return 0;
end;