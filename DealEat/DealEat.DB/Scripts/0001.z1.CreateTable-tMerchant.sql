create table dealeat.tMerchant
(
	MerchantId int,

	constraint PK_tMerchant primary key(MerchantId),
	constraint FK_dealeat_tMerchant_tUser foreign key(MerchantId) references dealeat.tUser(UserId)
);