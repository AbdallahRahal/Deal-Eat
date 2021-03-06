create table dealeat.tRestaurant_Category
(
	Restaurant_CategoryId int identity(0, 1),
	RestaurantId int not null,
	CategoryId int not null,

	constraint PK_dealeat_tRestaurant_Category primary key(Restaurant_CategoryId),
	constraint FK_dealeat_tRestaurant_Category_tRestaurant foreign key(RestaurantId) references dealeat.tRestaurant_Category(RestaurantId),
	constraint FK_dealeat_tRestaurant_Category_tCategory foreign key(CategoryId) references dealeat.tRestaurant_Category(CategoryId)
);
insert into dealeat.tRestaurant_Category(RestaurantId, CategoryId) values(0, 0);