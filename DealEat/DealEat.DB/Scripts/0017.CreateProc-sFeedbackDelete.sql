create proc dealeat.sFeedbackDelete
(
	@FeedbackId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if not exists(select * from dealeat.tFeedback f where f.FeedbackId = @FeedbackId)
	begin
		rollback;
		return 1;
	end;

	delete dealeat.tFeedback where FeedbackId = @FeedbackId;
	commit;

	return 0;
end;