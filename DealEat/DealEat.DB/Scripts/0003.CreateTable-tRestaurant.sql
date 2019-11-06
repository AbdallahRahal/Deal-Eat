create table dealeat.tRestaurant
(
	RestaurantId int identity(0, 1),
	[Name] nvarchar(45) collate Latin1_General_100_CI_AS not null,
	PhotoLink nvarchar(45) collate Latin1_General_100_CI_AS,
	UserId int not null,

	constraint PK_dealeat_tRestaurant primary key(RestaurantId),
	constraint FK_dealeat_tRestaurant_tUser foreign key(UserId) references dealeat.tRestaurant(UserId)
);
insert into dealeat.tRestaurant([Name], User_id) values(N'N.A.', 0);