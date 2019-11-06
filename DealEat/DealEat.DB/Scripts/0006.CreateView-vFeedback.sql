create view dealeat.vFeedback
as
	select
		FeedbackId = f.Feedback,
		Note = f.Note,
		Feedback = f.Feedback,
		UserId = f.UserId,
		RestaurantId = f.RestaurantId
	from dealeat.uFeeback f
	where f.FeedbackId <> 0;