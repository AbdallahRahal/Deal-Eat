create view dealeat.vSold
as
	select
		SoldId = s.SoldId,
		Reduction = s.Reduction,
		[Start_Date] = s.[Start_Date],
		[End_Date] = s.[End_Date]
	from dealeat.sSold s
	where s.SoldId <> 0