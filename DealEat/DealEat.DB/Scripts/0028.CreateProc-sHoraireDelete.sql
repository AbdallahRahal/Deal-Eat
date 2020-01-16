create proc dealeat.sHoraireDelete
(
	@HoraireId int
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	delete from dealeat.tHoraire where HoraireId = @HoraireId;

	commit;
	return 0;
end;