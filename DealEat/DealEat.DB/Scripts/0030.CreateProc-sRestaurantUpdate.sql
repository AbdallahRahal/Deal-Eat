create proc dealeat.sRestaurantUpdate
(
    @RestaurantId   int,
    @Name   nvarchar(45),
    @Adresse    nvarchar(255),
    @PhotoLink    nvarchar(255),
    @Telephone int
    
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	if not exists(select * from dealeat.tRestaurant r where r.RestaurantId = @RestaurantId)
	begin
		rollback;
		return 1;
	end;

	update dealeat.tRestaurant
	set Name = @Name, Adresse = @Adresse, PhotoLink = @PhotoLink, Telephone=@Telephone
	where RestaurantId = @RestaurantId;
	
	commit;
    return 0;
end;