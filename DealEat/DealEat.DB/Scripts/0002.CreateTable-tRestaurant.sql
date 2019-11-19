create table dealeat.tRestaurant
(
	RestaurantId int identity(0, 1),
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	Adresse nvarchar(255) collate Latin1_General_100_CI_AS not null,
	PhotoLink nvarchar(255) collate Latin1_General_100_CI_AS not null,
	Telephone int,
	MerchantId int not null,

	constraint PK_dealeat_tRestaurant primary key(RestaurantId),
	constraint FK_dealeat_tRestaurant_tMerchant foreign key(MerchantId) references dealeat.tMerchant(MerchantId)
);