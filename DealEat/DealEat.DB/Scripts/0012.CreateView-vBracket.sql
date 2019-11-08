create view dealeat.vBracket
as
	select
		-- Bracket
		BracketId = b.BracketId,
		[Name] = b.[Name],
		[Type] = b.[Type],
		PhotoLink = b.PhotoLink,
		-- Sold
		SoldId = s.SoldId,
		Reduction = s.Reduction
	from dealeat.tBracket b
	left join dealeat.tSold s on tBracket.BracketId = tSold.BracketId