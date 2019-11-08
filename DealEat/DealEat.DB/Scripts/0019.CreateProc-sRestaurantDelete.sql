create proc dealeat.sRestaurantDelete
(
	@RestaurantId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if not exists(select * from dealeat.tRestaurant r where r.RestaurantId = @RestaurantId)
	begin
		rollback;
		return 1;
	end;

	delete from dealeat.tRestaurant where RestauranttId = @RestaurantId;

	commit;
	return 0;
end;