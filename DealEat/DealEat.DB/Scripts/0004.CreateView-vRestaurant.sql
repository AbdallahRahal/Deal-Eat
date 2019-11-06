create view dealeat.vRestauraut
as
	select
		RestaurantId = r.RestaurantId,
		[Name] = r.[Name],
		PhotoLink = r.Photolink,
		UserId = r.UserId
	from dealeat.uRestaurant r
	where r.RestaurantId <> 0;