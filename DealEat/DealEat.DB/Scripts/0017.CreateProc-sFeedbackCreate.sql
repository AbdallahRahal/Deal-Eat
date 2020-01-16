create proc dealeat.sFeedbackCreate
(
	@Note int,
	@Feedback nvarchar(45),
	@Date date,
	@UserId int,
	@RestaurantId int,
	@FeedbackId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from dealeat.uFeedback f where f.Note = @Note and f.Feedback = @Feedback)
	begin
		rollback;
		return 1;
	end;

	set @FeedbackId = scope_identity();

	commit;
	return 0;
end;