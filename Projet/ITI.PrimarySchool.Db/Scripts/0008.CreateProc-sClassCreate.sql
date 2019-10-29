create proc ps.sClassCreate
(
	@Name nvarchar(8),
	@Level varchar(3),
	@ClassId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if @Level not in('CP', 'CE1', 'CE2', 'CM1', 'CM2')
	begin
		rollback;
		return 1;
	end;

	if exists(select * from ps.tClass c where c.[Name] = @Name)
	begin
		rollback;
		return 2;
	end;

	insert into ps.tClass([Name], [Level], TeacherId)
	               values(@Name,  @Level,  0);

	set @ClassId = scope_identity();

	commit;
	return 0;
end;