create proc dealeat.sUserDelete
(
	@UserId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if not exists(select * from dealeat.tUser u where u.UserId = @UserId)
	begin
		rollback;
		return 1;
	end;

	delete dealeat.tFeedback where CustomerId = @UserId;
	delete dealeat.tUser where UserId = @UserId;
	commit;

	return 0;
end;