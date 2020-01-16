create proc dealeat.sCategoryCreate
(
	@Name nvarchar(45),
	@CategoryId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	set @CategoryId = scope_identity();

	commit;
	return 0;
end;