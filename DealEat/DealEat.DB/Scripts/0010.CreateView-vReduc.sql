create view dealeat.vReduc
as
	select
		-- Restaurant
		RestaurantId = r.RestaurantId,
		[Name] = r.[Name],
		[Type] = r.[Type],
		PhotoLink = r.PhotoLink,
		-- Sold
		SoldId = s.SoldId,
		Reduction = s.Reduction
	from dealeat.tRestaurant r
	left join dealeat.tSold s on tRestaurant.RestaurantId = tSold.RestaurantId