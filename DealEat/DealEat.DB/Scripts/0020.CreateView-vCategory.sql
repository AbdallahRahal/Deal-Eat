create view dealeat.vCategory
as
	select
		CategoryId = c.CategoryId,
		Category = c.Category
	from dealeat.cCategory c
	where c.CategoryId <> 0