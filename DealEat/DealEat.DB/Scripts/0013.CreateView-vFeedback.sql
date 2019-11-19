create view dealeat.vFeedback
as
	select
		-- User
		CustomerId = cc.CustomerId,
		Pseudo = u.Pseudo,
		-- Feedback
		FeedbackId = f.FeedbackId,
		Note = f.Note,
		Feedback = f.Feedback
	from dealeat.tUser u
	--left join user & customer
	left join dealeat.tCustomer cc on cc.CustomerId = u.UserId
	--left join customer & feedback
	left join dealeat.tFeedback f on cc.CustomerId = f.CustomerId