create proc dealeat.sSoldDelete
(
	@SoldId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	delete from dealeat.tSold where SoldId = @SoldId;

	commit;
	return 0;
end;