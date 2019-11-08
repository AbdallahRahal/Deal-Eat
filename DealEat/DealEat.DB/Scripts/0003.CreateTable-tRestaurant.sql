create table dealeat.tRestaurant
(
	RestaurantId int identity(0, 1),
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	Adresse nvarchar(255) collate Latin1_General_100_CI_AS not null,
	PhotoLink nvarchar(300) collate Latin1_General_100_CI_AS not null,
	Telephone int(10) collate Latin1_General_100_CI_AS not null,
	UserId int not null,

	constraint PK_dealeat_tRestaurant primary key(RestaurantId),
	constraint FK_dealeat_tRestaurant_tUser foreign key(UserId) references dealeat.tRestaurant(UserId)
);
insert into dealeat.tRestaurant([Name], Adresse, PhotoLink, Telephone, UserId) values('RestaurantName', 'RestaurantAdresse', 'RestaurantPhotoLink', 0601020304, 0);