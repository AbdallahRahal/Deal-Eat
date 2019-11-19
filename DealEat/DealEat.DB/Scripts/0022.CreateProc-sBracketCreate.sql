create proc dealeat.sBracketCreate
(
	@Name nvarchar(45),
	@Information text,
	@PhotoLink nvarchar(45),
	@Price int,
	@RestaurantId int,
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