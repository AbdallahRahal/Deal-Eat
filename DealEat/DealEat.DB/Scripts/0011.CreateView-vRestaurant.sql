create view dealeat.vRestaurant
as
	select
		-- User
		UserId = u.UserId,
		Pseudo = u.Pseudo,
		-- Restaurant
		RestaurantId = r.RestaurantId,
		[Name] = r.[Name],
		[Type] = r.[Type],
		PhotoLink = r.PhotoLink,
		Adresse = r.Adresse,
		Telephone = r.Telephone,
		-- Feedback
		FeedbackId = f.FeedbackId,
		Note = f.Note,
		Feedback = f.Feedback
	from dealeat.tUser u
	left join dealeat.tRestaurant r on tUser.UserId = tRestaurant.UserId
	left join dealeat.tFeedback f on tUser.UserId = tFeedback.UserId