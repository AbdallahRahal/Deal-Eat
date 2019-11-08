create view dealeat.vFeedback
as
	select
		-- User
		UserId = u.UserId,
		Pseudo = u.Pseudo,
		-- Feedback
		FeedbackId = f.FeedbackId,
		Note = f.Note,
		Feedback = f.Feedback
	from dealeat.tUser u
	left join dealeat.tFeedback f on tUser.UserId = tFeedback.UserId