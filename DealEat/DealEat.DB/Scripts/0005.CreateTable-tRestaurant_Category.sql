create table dealeat.tRestaurant_Category
(
	RestaurantId int not null,
	CategoryId int not null,

	constraint PK_dealeat_tRestaurant_Category primary key(RestaurantId),
	constraint PK_dealeat_tRestaurant_Category primary key(CategoryId),
	constraint FK_dealeat_tRestaurant_Category_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant(RestaurantId),
	constraint FK_dealeat_tRestaurant_Category_tCategory foreign key(CategoryId) references dealeat.tCategory(CategoryId)
);
