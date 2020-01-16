create proc dealeat.sHoraireCreate
(
	@Day enum,
	@OuvertureMatin TIME,
	@FermetureMatin TIME,
	@OuvertureAprem TIME,
	@FermetureAprem TIME,
	@RestaurantId int,
	@HoraireId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	set @HoraireId = scope_identity();

	commit;
	return 0;
end;