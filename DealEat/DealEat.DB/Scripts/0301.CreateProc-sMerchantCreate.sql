create proc dealeat.sMerchantCreate
(
    @MerchantId int out
)
as
begin
	set xact_abort on;
	set transaction isolation level serializable;

	begin tran;

	if exists(select * from dealeat.tMerchant where MerchantId = @MerchantId)
	begin
		rollback;
		return 1;
	end;

	insert into dealeat.tMerchant( MerchantId) values(@MerchantId);
	

	commit;	
	return 0;
end;