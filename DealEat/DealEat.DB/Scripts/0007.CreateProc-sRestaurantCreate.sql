create proc dealeat.sRestaurantCreate
(
	@Name nvarchar(45),
	@PhotoLink nvarchar(45),
	@UserId int,
	@RestaurantId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from dealeat.uRestaurant r where r.[Name] = @Name and r.PhotoLink = @PhotoLink)
	begin
		rollback;
		return 1;
	end;

	set @RestaurantId = scope_identity();
	commit;
	return 0;
end;