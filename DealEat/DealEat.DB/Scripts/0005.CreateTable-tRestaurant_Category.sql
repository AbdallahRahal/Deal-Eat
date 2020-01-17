create table dealeat.tRestaurant_Category
(
	Restaurant_CategoryId int,
	RestaurantId int not null,
	CategoryId int not null,

	constraint PK_dealeat_tRestaurant_Category primary key(Restaurant_CategoryId),

	constraint FK_dealeat_tRestaurant_Category_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),

);
