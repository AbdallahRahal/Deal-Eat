create view dealeat.vRestaurant
as
	select
		-- Merchant
		MerchantId = m.MerchantId,
		Pseudo = u.Pseudo,
		-- Restaurant
		RestaurantId = r.RestaurantId,
		[Name] = r.[Name],
		PhotoLink = r.PhotoLink,
		Adresse = r.Adresse,
		Telephone = r.Telephone,
		-- Category
		CategoryId = c.CategoryId,
		CategoryName = c.[Name],
		-- Feedback
		FeedbackId = f.FeedbackId,
		Note = f.Note,
		Feedback = f.Feedback
	from dealeat.tUser u
	--left join user & merchant
	left join dealeat.tMerchant m on u.UserId = m.MerchantId
	--left join merchant & restaurant
	left join dealeat.tRestaurant r on m.MerchantId = r.MerchantId
	--left join feedback & restaurant
	left join dealeat.tFeedback f on r.RestaurantId = f.RestaurantId
	--left join restaurant & category
	left join dealeat.tRestaurant_Category rc on r.RestaurantId = rc.RestaurantId
	left join dealeat.tCategory c on r.RestaurantId = c.CategoryId