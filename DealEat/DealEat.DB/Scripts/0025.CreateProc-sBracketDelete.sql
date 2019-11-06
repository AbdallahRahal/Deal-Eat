create proc dealeat.sBracketDelete
(
	@BracketId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	delete from dealeat.tBracket where BracketId = @BracketId;

	commit;
	return 0;
end;