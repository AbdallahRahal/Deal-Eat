create view dealeat.vReduc
as
	select
		-- Restaurant
		RestaurantId = r.RestaurantId,
		RestaurantName = r.[Name],
		PhotoLink = r.PhotoLink,
		-- Category
		CategoryId = c.CategoryId,
		CategoryName = c.[Name],
		-- Sold
		SoldId = s.SoldId,
		Reduction = s.Reduction
	from dealeat.tRestaurant r
	--left join restaurant & bracket
	left join dealeat.tBracket b on r.RestaurantId = b.RestaurantId
	--left join restaurant & category
	left join dealeat.tRestaurant_Category rc on r.RestaurantId = rc.RestaurantId
	left join dealeat.tCategory c on r.RestaurantId = c.CategoryId
	--left join sold & bracket
	left join dealeat.tSold s on b.BracketId = s.BracketId

