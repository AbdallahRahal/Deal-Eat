create table dealeat.tMerchant
(
	MerchantId int identity(0, 1),

	constraint PK_tMerchant primary key(MerchantId),
	constraint FK_dealeat_tMerchant_tUser foreign key(MerchantId) references dealeat.tUser(UserId)
);