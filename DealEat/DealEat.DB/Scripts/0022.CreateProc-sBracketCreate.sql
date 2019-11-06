create proc dealeat.sBracketCreate
(
	@Type nvarchar(45),
	@BracketId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	set @BracketId = scope_identity();

	commit;
	return 0;
end;