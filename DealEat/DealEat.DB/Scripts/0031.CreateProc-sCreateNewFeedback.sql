create procedure dealeat.sCreateNewFeedback
(
    @Note   int,
    @Feedback    nvarchar(255),
    @CustomerId   int,
	@RestaurantId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;


    INSERT INTO [DealEat].[dealeat].[tFeedback]
    (Note ,Feedback, CustomerId, RestaurantId)
        VALUES
            (@Note, @Feedback, @CustomerId, @RestaurantId);

	set @RestaurantId = scope_identity();

	commit;
	return 0;
end;