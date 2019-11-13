create view dealeat.vRestaurant
as
	select
		-- User
		UserId = u.UserId,
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
	--left join user & restaurant
	left join dealeat.tRestaurant r on u.UserId = r.UserId
	--left join user & feedback
	left join dealeat.tFeedback f on u.UserId = f.UserId
	--left join restaurant & category
	left join dealeat.tRestaurant_Category rc on r.RestaurantId = rc.RestaurantId
	left join dealeat.tCategory c on r.RestaurantId = c.CategoryId