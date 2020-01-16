create proc dealeat.sSoldCreate	
(
	@Reduction int,
	@Start_Date date,
	@End_Date date,
	@BracketId int,
	@SoldId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	set @SoldId = scope_identity();

	commit;
	return 0;
end;