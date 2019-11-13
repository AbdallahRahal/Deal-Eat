create view dealeat.vBracket
as
	select
		-- Bracket
		BracketId = b.BracketId,
		[Name] = b.[Name],
		PhotoLink = b.PhotoLink,
		-- Sold
		SoldId = s.SoldId,
		Reduction = s.Reduction
	from dealeat.tBracket b
	--left join bracket & sold
	left join dealeat.tSold s on b.BracketId = s.BracketId