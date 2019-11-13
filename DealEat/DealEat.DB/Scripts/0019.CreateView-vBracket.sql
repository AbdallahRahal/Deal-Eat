create view dealeat.vBracket
as
	select
		BracketId = b.BracketId,
		[Type] = b.[Type]
	from dealeat.bBracket b
	where b.BracketId <> 0;